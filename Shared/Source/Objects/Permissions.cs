using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Universalis
{
    public enum PermissionType
    {
        White,
        Black
    }

    public class PermissionSet<T>
    {
        public PermissionSet( PermissionType type )
        {
            Type = type;
        }

        public PermissionType Type;

        public HashSet<T> Values = new HashSet<T>();

        public void Set( PermissionSet<T> permissionSet )
        {
            Type = permissionSet.Type;

            Values.Clear();

            Values.UnionWith( permissionSet.Values );
        }

        public bool Equals( PermissionSet<T> permissionSet )
        {
            if( null == permissionSet )
            {
                throw new ArgumentNullException( nameof( permissionSet ) );
            }

            if( Type != permissionSet.Type )
            {
                return false;
            }

            if( !Values.SetEquals( permissionSet.Values ) )
            {
                return false;
            }

            return true;
        }

        public bool Granted( T value )
        {
            if( Values.Count > 0 )
            {
                switch( Type )
                {
                    case PermissionType.White:
                        return Values.Contains( value );

                    case PermissionType.Black:
                        return !Values.Contains( value );

                    default:
                        return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

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

            TypeWhitelist.Clear();
            TypeWhitelist.UnionWith( permissions.TypeWhitelist );

            TypeBlacklist.Clear();
            TypeBlacklist.UnionWith( permissions.TypeBlacklist );

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

            if( !FactionWhitelist.SetEquals( permissions.FactionWhitelist ) )
            {
                return ( false );
            }

            if( !FactionBlacklist.SetEquals( permissions.FactionBlacklist ) )
            {
                return ( false );
            }

            if( !ArchetypeWhitelist.SetEquals( permissions.ArchetypeWhitelist ) )
            {
                return ( false );
            }

            if( !ArchetypeBlacklist.SetEquals( permissions.ArchetypeBlacklist ) )
            {
                return ( false );
            }

            if( !TypeWhitelist.SetEquals( permissions.TypeWhitelist ) )
            {
                return ( false );
            }

            if( !TypeBlacklist.SetEquals( permissions.TypeBlacklist ) )
            {
                return ( false );
            }

            if( !SizeWhitelist.SetEquals( permissions.SizeWhitelist ) )
            {
                return ( false );
            }

            if( !SizeBlacklist.SetEquals( permissions.SizeBlacklist ) )
            {
                return ( false );
            }

            if( !MovementTypeWhitelist.SetEquals( permissions.MovementTypeWhitelist ) )
            {
                return ( false );
            }

            if( !MovementTypeBlacklist.SetEquals( permissions.MovementTypeBlacklist ) )
            {
                return ( false );
            }

            return ( true );
        }

        public (bool status, String reason) IsValid()
        {
            if( FactionWhitelist.Count > 0 && FactionBlacklist.Count > 0 )
            {
                return (false, "White- und Blacklist für Fraktionen können nicht gleichzeitig gefüllt sein.");
            }

            if( ArchetypeWhitelist.Count > 0 && ArchetypeBlacklist.Count > 0 )
            {
                return ( false, "White- und Blacklist für Archetypen können nicht gleichzeitig gefüllt sein." );
            }

            if( TypeWhitelist.Count > 0 && TypeBlacklist.Count > 0 )
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
                
                if( TypeWhitelist.Count > 0 || TypeBlacklist.Count > 0 )
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

        public bool Granted( Archetype archetype )
        {
            if( ( FactionWhitelist.Count > 0 ) && ( !FactionWhitelist.Contains( archetype.Faction ) ) )
            {
                return ( false );
            }

            if( ( FactionBlacklist.Count > 0 ) && ( !FactionBlacklist.Contains( archetype.Faction ) ) )
            {
                return ( false );
            }

            if( ( ArchetypeWhitelist.Count > 0 ) && ( !ArchetypeWhitelist.Contains( archetype ) ) )
            {
                return ( false );
            }

            if( ( ArchetypeBlacklist.Count > 0 ) && ( !ArchetypeBlacklist.Contains( archetype ) ) )
            {
                return ( false );
            }

            if( ( TypeWhitelist.Count > 0 ) && ( !TypeWhitelist.Contains( archetype.Type ) ) )
            {
                return ( false );
            }

            if( ( TypeBlacklist.Count > 0 ) && ( !TypeBlacklist.Contains( archetype.Type ) ) )
            {
                return ( false );
            }

            if( ( SizeWhitelist.Count > 0 ) && ( !SizeWhitelist.Contains( archetype.Size ) ) )
            {
                return ( false );
            }

            if( ( SizeBlacklist.Count > 0 ) && ( !SizeBlacklist.Contains( archetype.Size ) ) )
            {
                return ( false );
            }

            if( ( MovementTypeWhitelist.Count > 0 ) && ( !MovementTypeWhitelist.Contains( archetype.MovementType ) ) )
            {
                return ( false );
            }

            if( ( MovementTypeBlacklist.Count > 0 ) && ( !MovementTypeBlacklist.Contains( archetype.MovementType ) ) )
            {
                return ( false );
            }

            return ( true );
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
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Erlaubte Archetypen: " + String.Join( ", ", ArchetypeWhitelist.Select( x => x.Name ) );
            }
            
            if( ArchetypeBlacklist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Verbotene Archetypen: " + String.Join( ", ", ArchetypeBlacklist.Select( x => x.Name ) );
            }

            if( TypeWhitelist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Erlaubte Typen: " + String.Join( ", ", TypeWhitelist.Select( x => x.ToString() ) );
            }

            if( TypeBlacklist.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += "Verbotene Typen: " + String.Join( ", ", TypeBlacklist.Select( x => x.ToString() ) );
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

        public HashSet<Archetype.EType> TypeWhitelist = new HashSet<Archetype.EType>();
        public HashSet<Archetype.EType> TypeBlacklist = new HashSet<Archetype.EType>();

        public HashSet<Archetype.ESize> SizeWhitelist = new HashSet<Archetype.ESize>();
        public HashSet<Archetype.ESize> SizeBlacklist = new HashSet<Archetype.ESize>();

        public HashSet<Archetype.EMovementType> MovementTypeWhitelist = new HashSet<Archetype.EMovementType>();
        public HashSet<Archetype.EMovementType> MovementTypeBlacklist = new HashSet<Archetype.EMovementType>();
    }
}
