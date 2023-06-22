namespace RBTB_ServiceAccount.Client.Extensions
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using JetBrains.Annotations;
    using RBTB_ServiceAccount.Client.Common;
    using RestSharp;

    public static class RequestHelper
    {
        public static string GenerateParametersString( this IDictionary<string, string> properties )
        {
            return properties != null && properties.Count != 0 ? "?" + string.Join( "&", properties.Select( a => $"{a.Key}={a.Value}" ) ) : string.Empty;
        }

        public static Method GetMethod( this RequestMethod method )
        {
            return method switch
            {
                RequestMethod.DELETE => Method.DELETE,
                RequestMethod.PUT => Method.PUT,
                RequestMethod.POST => Method.POST,
                _ => Method.GET,
            };
        }

        public static void AddStringIfNotEmptyOrWhiteSpace( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, [CanBeNull] string? value )
        {
            if ( string.IsNullOrWhiteSpace( value ) ) return;

            dictionary.Add( key, value );
        }

        public static void AddSimpleStruct<T>( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, T value ) where T : struct
            => dictionary.Add( key, value.ToString() );

        public static void AddSimpleStructIfNotNull<T>( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, T? value ) where T : struct
        {
            if ( !value.HasValue ) return;

            dictionary.Add( key, value.Value.ToString() );
        }

        public static void AddEnum<T>( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, T value ) where T : struct
        {
            dictionary.Add( key, ( Convert.ToInt32( value ) ).ToString() );
            //dictionary.Add( key, value.ToString() );
        }

        public static void AddEnumIfNotNull<T>( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, [CanBeNull] T? value ) where T : struct
        {
            if ( !value.HasValue ) return;
            
            dictionary.Add( key, ( Convert.ToInt32( value ) ).ToString() );
        }

        public static void AddArray( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, [CanBeNull] string[] value )
        {
            if ( value == null ) return;

            var nextProperty = string.Empty;

            for ( int i = 0; i < value.Length; i++ )
            {
                if ( i == 0 )
                {
                    nextProperty += value[i].ToString();
                }
                else
                {
                    nextProperty += "&" + key + "=" + value[i].ToString();
                }
            }

            dictionary.Add( key, nextProperty );
        }

        public static void AddDateTime( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, [CanBeNull] DateTime? value )
        {
            if ( value is null ) return;

            //2023-06-22T10:51:38.585Z
            dictionary.Add( key, $"{value.Value.ToString( "yyyy-MM-dd" )}T{value.Value.ToString( "H:mm:ss.fff" )}" );
        }

        public static void AddDecimal( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, decimal value ) =>
            dictionary.Add( key, value.ToFormattedString() );

        public static void AddDecimalIfNotNull( [NotNull] this IDictionary<string, string> dictionary,
            [NotNull] string key, decimal? value )
        {
            if ( !value.HasValue ) return;

            dictionary.Add( key, value.Value.ToFormattedString() );
        }

        private static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo { NumberDecimalSeparator = @"." };

        [NotNull]
        private static string ToFormattedString( this decimal value ) => value.ToString( NumberFormat );
    }
}