﻿// =====================================//==============================================================//
//                                      //                                                              //
// Project="RC.Framework"               //          Copyright © 2009 Osamu TAKEUCHI <osamu@big.jp>      //
// Author= {"Osamu"}                    //                                                              //
//                                      //                            Osamu                             //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace RC.Framework.Yaml
{
    /// <summary>
    /// Validates a text as a global tag in YAML.
    /// 
    /// <a href="http://www.faqs.org/rfcs/rfc4151.html">RFC4151 - The 'tag' URI Scheme</a>>
    /// </summary>
    internal class YamlTagValidator: Parser<YamlTagValidator.Status>
    {
        /// <summary>
        /// Not used in this parser
        /// </summary>
        public struct Status { }

        public static YamlTagValidator Default
        {
            get { return default_; }
        }
        static YamlTagValidator default_ = new YamlTagValidator();

        /// <summary>
        /// Validates a text as a global tag in YAML.
        /// </summary>
        /// <param name="tag">A candidate for a global tag in YAML.</param>
        /// <returns>True if <paramref name="tag"/> is  a valid global tag.</returns>
        public bool IsValid(string tag)
        {
            text = tag;
            p = 0;
            return TagUri();
        }

        private bool TagUri()
        {
            return
                Accept("tag:") &&
                taggingEntity() &&
                Accept(c: ':') &&
                specific() &&
                Optional(
                    Accept(c: '#') &&
                    fragment()
                ) &&
                EndOfString();
        }

        private bool taggingEntity()
        {
            return
                RewindUnless(() =>
                    authorityName() &&
                    Accept(c: ',') &&
                    date()
                );
        }

        private bool authorityName()
        {
            return
                emailAddress() ||
                DNSname();
        }

        private bool DNSname()
        {
            return
                DNScomp() &&
                Repeat(() =>
                    Accept(c: '.') &&
                    DNScomp()
                );
        }

        private bool DNScomp()
        {
            return RewindUnless(() =>
                OneAndRepeat(alphaNum) &&
                Repeat(() => RewindUnless(() =>
                    Accept(c: '-') &&
                    OneAndRepeat(alphaNum)
                ))
            );
        }

        private bool alphaNum()
        {
            return
                Accept(alphaNumCharset);
        }
        Func<char, bool> alphaNumCharset = Charset(c =>
                c < 0x100 && (
                    ( '0' <= c && c <= '9' ) ||
                    ( 'A' <= c && c <= 'Z' ) ||
                    ( 'a' <= c && c <= 'z' )
                )
            );

        private bool emailAddress()
        {
            return RewindUnless(() =>
                OneAndRepeat(() => alphaNum() || Accept(c: '-') || Accept(c: '.') || Accept(c: '_')) &&
                Accept(c: '@') &&
                DNSname()
            );
        }

        private bool date()
        {
            return
                Accept(dateRegex);
        }
        Regex dateRegex = new Regex(@"(19[89][0-9]|20[0-4][0-9])(-(0[1-9]|1[0-2])(-(0[1-9]|[12][0-9]|3[01]))?)?");

        private bool num()
        {
            return
                Accept(numCharset);
        }
        Func<char, bool> numCharset = Charset(c =>
                c < 0x100 && 
                ( '0' <= c && c <= '9' ) 
            );

        private bool specific()
        {
            return
                Repeat(() => pchar() || Accept(c: '/') || Accept(c: '?'));
        }

        private bool fragment()
        {
            return
                Repeat(() => pchar() || Accept(c: '/') || Accept(c: '?'));
        }

        private bool EndOfString()
        {
            return text.Length == p;
        }

        bool pchar()
        {
            return
                Accept(pcharCharsetSub) ||
                RewindUnless(() =>
                    Accept(c: '%') &&
                    hexDig() &&
                    hexDig()
                );
        }
        Func<char, bool> pcharCharsetSub = Charset(c =>
                c < 0x100 && (
                    ( '0' <= c && c <= '9' ) ||
                    ( 'A' <= c && c <= 'Z' ) ||
                    ( 'a' <= c && c <= 'z' ) ||
                    "-._~!$&'()*+,;=:@".Contains(c)
                )
            );

        bool hexDig()
        {
            return Accept(hexDigCharset);
        }
        Func<char, bool> hexDigCharset = Charset(c =>
                c < 0x100 && (
                    ( '0' <= c && c <= '9' ) ||
                    ( 'A' <= c && c <= 'F' ) ||
                    ( 'a' <= c && c <= 'f' )
                )
            );

    }

}
