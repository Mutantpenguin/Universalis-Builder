using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Universalis
{
    class Permissions
    {
        public (bool, String reason) IsValid()
        {
            if( ArchetypeWhitelist.Count > 0 && ArchetypeBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Archetypen können nicht gleichzeitig gefüllt sein." );
            }

            if( FactionWhitelist.Count > 0 && FactionBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Fraktionen können nicht gleichzeitig gefüllt sein." );
            }

            if( ArchetypeTypeWhitelist.Count > 0 && ArchetypeTypeBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Typen können nicht gleichzeitig gefüllt sein." );
            }

            if( SizeWhitelist.Count > 0 && SizeBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Größen können nicht gleichzeitig gefüllt sein." );
            }

            if( MovementTypeWhitelist.Count > 0 && MovementTypeBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Bewegungsarten können nicht gleichzeitig gefüllt sein." );
            }

            if( ArchetypeWhitelist.Count > 0 )
            {
                if( FactionWhitelist.Count > 0 || FactionBlacklist.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Fraktionen gefüllt sein." );
                }
                
                if( ArchetypeTypeWhitelist.Count > 0 || ArchetypeTypeBlacklist.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Typen gefüllt sein." );
                }

                if( SizeWhitelist.Count > 0 || SizeBlacklist.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Größen gefüllt sein." );
                }

                if( MovementTypeWhitelist.Count > 0 || MovementTypeBlacklist.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Bewegungsarten gefüllt sein." );
                }
            }

            return ( true, String.Empty) ;
        }

        public string Summary()
        {
            string summary = String.Empty;

            if( ArchetypeWhitelist.Count > 0 )
            {
                summary += "Erlaubte Archetypen: " + String.Join( ", ", ArchetypeWhitelist.Select( x => x.Name ) );
            }
            
            if( ArchetypeBlacklist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Verbotene Archetypen: " + String.Join( ", ", ArchetypeBlacklist.Select( x => x.Name ) );
            }

            if( FactionWhitelist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Erlaubte Fraktionen: " + String.Join( ", ", FactionWhitelist.Select( x => x.Name ) );
            }

            if( FactionBlacklist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Verbotene Fraktionen: " + String.Join( ", ", FactionBlacklist.Select( x => x.Name ) );
            }

            if( ArchetypeTypeWhitelist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Erlaubte Typen: " + String.Join( ", ", ArchetypeTypeWhitelist.Select( x => x.ToString() ) );
            }

            if( ArchetypeTypeBlacklist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Verbotene Typen: " + String.Join( ", ", ArchetypeTypeBlacklist.Select( x => x.ToString() ) );
            }

            if( SizeWhitelist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Erlaubte Größen: " + String.Join( ", ", SizeWhitelist.Select( x => x.ToString() ) );
            }

            if( SizeBlacklist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Verbotene Größen: " + String.Join( ", ", SizeBlacklist.Select( x => x.ToString() ) );
            }

            if( MovementTypeWhitelist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Erlaubte Bewegungsarten: " + String.Join( ", ", MovementTypeWhitelist.Select( x => x.ToString() ) );
            }

            if( MovementTypeBlacklist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Verbotene Bewegungsarten: " + String.Join( ", ", MovementTypeBlacklist.Select( x => x.ToString() ) );
            }

            return ( summary );
        }

        [JsonConverter( typeof( JsonArchetypeSetConverter ) )]
        public HashSet<Archetype> ArchetypeWhitelist;
        [JsonConverter( typeof( JsonArchetypeSetConverter ) )]
        public HashSet<Archetype> ArchetypeBlacklist;

        [JsonConverter( typeof( JsonFactionSetConverter ) )]
        public HashSet<Faction> FactionWhitelist;
        [JsonConverter( typeof( JsonFactionSetConverter ) )]
        public HashSet<Faction> FactionBlacklist;

        public HashSet<Archetype.EType> ArchetypeTypeWhitelist;
        public HashSet<Archetype.EType> ArchetypeTypeBlacklist;

        public HashSet<Archetype.ESize> SizeWhitelist;
        public HashSet<Archetype.ESize> SizeBlacklist;

        public HashSet<Archetype.EMovementType> MovementTypeWhitelist;
        public HashSet<Archetype.EMovementType> MovementTypeBlacklist;
    }
}
