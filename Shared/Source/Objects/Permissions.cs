using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return ( false, "White- und Blacklist für Archetyp Typen können nicht gleichzeitig gefüllt sein." );
            }

            if( SizeWhitelist.Count > 0 && SizeBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Größen können nicht gleichzeitig gefüllt sein." );
            }

            if( MovementTypeWhitelist.Count > 0 && MovementTypeBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Bewegungstypen können nicht gleichzeitig gefüllt sein." );
            }

            if( ArchetypeWhitelist.Count > 0 )
            {
                if( FactionWhitelist.Count > 0 || FactionBlacklist.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Fraktionen gefüllt sein." );
                }
                
                if( ArchetypeTypeWhitelist.Count > 0 || ArchetypeTypeBlacklist.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Archetyp Typen gefüllt sein." );
                }

                if( SizeWhitelist.Count > 0 || SizeBlacklist.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Größen gefüllt sein." );
                }

                if( MovementTypeWhitelist.Count > 0 || MovementTypeBlacklist.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Bewegungstypen gefüllt sein." );
                }
            }

            return ( true, String.Empty) ;
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
