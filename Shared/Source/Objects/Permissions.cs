using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Universalis
{
    public class Permissions
    {
        public Permissions()
        { }

        public Permissions( Permissions permissions )
            : this()
        {
            Set( permissions );
        }
        public void Set( Permissions permissions )
        {
            FactionWhitelist.Clear();
            FactionWhitelist.UnionWith( permissions.FactionWhitelist );

            FactionBlacklist.Clear();
            FactionBlacklist.UnionWith( permissions.FactionBlacklist );

            ArchetypeWhitelist.Clear();
            ArchetypeWhitelist.UnionWith( permissions.ArchetypeWhitelist );

            ArchetypeBlacklist.Clear();
            ArchetypeBlacklist.UnionWith( permissions.ArchetypeBlacklist );

            ArchetypeTypeWhitelist.Clear();
            ArchetypeTypeWhitelist.UnionWith( permissions.ArchetypeTypeWhitelist );

            ArchetypeTypeBlacklist.Clear();
            ArchetypeTypeBlacklist.UnionWith( permissions.ArchetypeTypeBlacklist );

            SizeWhitelist.Clear();
            SizeWhitelist.UnionWith( permissions.SizeWhitelist );

            SizeBlacklist.Clear();
            SizeBlacklist.UnionWith( permissions.SizeBlacklist );

            MovementTypeWhitelist.Clear();
            MovementTypeWhitelist.UnionWith( permissions.MovementTypeWhitelist );

            MovementTypeBlacklist.Clear();
            MovementTypeBlacklist.UnionWith( permissions.MovementTypeBlacklist );
        }

        public bool Equals( Permissions permissions )
        {
            if( null == permissions )
            {
                throw new ArgumentNullException( nameof( permissions ) );
            }

            if( !permissions.FactionWhitelist.SetEquals( FactionWhitelist ) )
            {
                return ( false );
            }

            if( !permissions.FactionBlacklist.SetEquals( FactionBlacklist ) )
            {
                return ( false );
            }

            if( !permissions.ArchetypeWhitelist.SetEquals( ArchetypeWhitelist ) )
            {
                return ( false );
            }

            if( !permissions.ArchetypeBlacklist.SetEquals( ArchetypeBlacklist ) )
            {
                return ( false );
            }

            if( !permissions.ArchetypeTypeWhitelist.SetEquals( ArchetypeTypeWhitelist ) )
            {
                return ( false );
            }

            if( !permissions.ArchetypeTypeBlacklist.SetEquals( ArchetypeTypeBlacklist ) )
            {
                return ( false );
            }

            if( !permissions.SizeWhitelist.SetEquals( SizeWhitelist ) )
            {
                return ( false );
            }

            if( !permissions.SizeBlacklist.SetEquals( SizeBlacklist ) )
            {
                return ( false );
            }

            if( !permissions.MovementTypeWhitelist.SetEquals( MovementTypeWhitelist ) )
            {
                return ( false );
            }

            if( !permissions.MovementTypeBlacklist.SetEquals( MovementTypeBlacklist ) )
            {
                return ( false );
            }

            return ( true );
        }

        public (bool, String reason) IsValid()
        {
            if( FactionWhitelist.Count > 0 && FactionBlacklist.Count > 0 )
            {
                return (false, "White- und Blacklist für Fraktionen können nicht gleichzeitig gefüllt sein.");
            }

            if( ArchetypeWhitelist.Count > 0 && ArchetypeBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Archetypen können nicht gleichzeitig gefüllt sein." );
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

            if( ArchetypeWhitelist.Count > 0 )
            {
                summary += "Erlaubte Archetypen: " + String.Join( ", ", ArchetypeWhitelist.Select( x => x.Name ) );
            }
            
            if( ArchetypeBlacklist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Verbotene Archetypen: " + String.Join( ", ", ArchetypeBlacklist.Select( x => x.Name ) );
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

        [JsonConverter( typeof( JsonFactionSetConverter ) )]
        public HashSet<Faction> FactionWhitelist = new HashSet<Faction>();
        [JsonConverter( typeof( JsonFactionSetConverter ) )]
        public HashSet<Faction> FactionBlacklist = new HashSet<Faction>();

        [JsonConverter( typeof( JsonArchetypeSetConverter ) )]
        public HashSet<Archetype> ArchetypeWhitelist = new HashSet<Archetype>();
        [JsonConverter( typeof( JsonArchetypeSetConverter ) )]
        public HashSet<Archetype> ArchetypeBlacklist = new HashSet<Archetype>();

        public HashSet<Archetype.EType> ArchetypeTypeWhitelist = new HashSet<Archetype.EType>();
        public HashSet<Archetype.EType> ArchetypeTypeBlacklist = new HashSet<Archetype.EType>();

        public HashSet<Archetype.ESize> SizeWhitelist = new HashSet<Archetype.ESize>();
        public HashSet<Archetype.ESize> SizeBlacklist = new HashSet<Archetype.ESize>();

        public HashSet<Archetype.EMovementType> MovementTypeWhitelist = new HashSet<Archetype.EMovementType>();
        public HashSet<Archetype.EMovementType> MovementTypeBlacklist = new HashSet<Archetype.EMovementType>();
    }
}
