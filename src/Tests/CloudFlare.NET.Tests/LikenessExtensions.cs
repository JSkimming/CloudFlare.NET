namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Ploeh.SemanticComparison;
    using Ploeh.SemanticComparison.Fluent;

    internal static class LikenessExtensions
    {
        public static Likeness<T, T> AsLikeness<T>(this T actual)
            where T : class
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual.AsSource().OfLikeness<T>();
        }

        public static Likeness<SettingSecurityHeader, SettingSecurityHeader> AsLikeness(
            this SettingSecurityHeader actual)
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual
                .AsSource()
                .OfLikeness<SettingSecurityHeader>()
                .With(s => s.StrictTransportSecurity)
                .EqualsWhen((a, e) => a.StrictTransportSecurity.AsLikeness().Equals(e.StrictTransportSecurity));
        }

        public static Likeness<CloudFlareResponseBase, CloudFlareResponseBase> AsLikeness(
            this CloudFlareResponseBase actual)
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual
                .AsSource()
                .OfLikeness<CloudFlareResponseBase>()
                .With(r => r.Errors)
                .EqualsWhen((a, e) => a.Errors.SequenceEqual(e.Errors))
                .With(r => r.Messages)
                .EqualsWhen((a, e) => a.Messages.SequenceEqual(e.Messages))
                .With(r => r.ResultInfo)
                .EqualsWhen((a, e) => a.ResultInfo.AsLikeness().Equals(e.ResultInfo));
        }

        public static Likeness<Zone, Zone> AsLikeness(this Zone actual)
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual
                .AsSource()
                .OfLikeness<Zone>()
                .With(z => z.NameServers)
                .EqualsWhen((a, e) => a.NameServers.SequenceEqual(e.NameServers))
                .With(z => z.OriginalNameServers)
                .EqualsWhen((a, e) => a.OriginalNameServers.SequenceEqual(e.OriginalNameServers));
        }

        public static Likeness<ZoneSetting<SettingMinify>, ZoneSetting<SettingMinify>> AsLikeness(
            this ZoneSetting<SettingMinify> actual)
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual
                .AsSource()
                .OfLikeness<ZoneSetting<SettingMinify>>()
                .With(s => s.Value)
                .EqualsWhen((a, e) => a.Value.AsLikeness().Equals(e.Value));
        }

        public static Likeness<ZoneSetting<SettingMobileRedirect>, ZoneSetting<SettingMobileRedirect>> AsLikeness(
            this ZoneSetting<SettingMobileRedirect> actual)
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual
                .AsSource()
                .OfLikeness<ZoneSetting<SettingMobileRedirect>>()
                .With(s => s.Value)
                .EqualsWhen((a, e) => a.Value.AsLikeness().Equals(e.Value));
        }

        public static Likeness<DnsRecord, DnsRecord> AsLikeness(this DnsRecord actual)
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual
                .AsSource()
                .OfLikeness<DnsRecord>()
                .With(z => z.Data)
                .EqualsWhen((a, e) => a.Data.ToString(Formatting.None) == e.Data.ToString(Formatting.None))
                .With(z => z.Meta)
                .EqualsWhen((a, e) => a.Meta.ToString(Formatting.None) == e.Meta.ToString(Formatting.None));
        }
    }
}
