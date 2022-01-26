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

        public PermissionSet( PermissionSet<T> permissionSet )
        {
            Set( permissionSet );
        }

        public PermissionType Type;

        public virtual HashSet<T> Values
        {
            get;
            set;
        } = new HashSet<T>();

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
                return false;
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
            FactionPermissions = new PermissionSet<Faction>( permissions.FactionPermissions );

            ArchetypePermissions = new PermissionSet<Archetype>( permissions.ArchetypePermissions );

            TypePermissions = new PermissionSet<Archetype.EType>( permissions.TypePermissions );

            SizePermissions = new PermissionSet<Archetype.ESize>( permissions.SizePermissions );

            MovementTypePermissions = new PermissionSet<Archetype.EMovementType>( permissions.MovementTypePermissions );
        }

        public bool Equals( Permissions permissions )
        {
            if( null == permissions )
            {
                throw new ArgumentNullException( nameof( permissions ) );
            }

            if( !FactionPermissions?.Equals( permissions.FactionPermissions ) ?? false )
            {
                return false;
            }

            if( !ArchetypePermissions?.Equals( permissions.ArchetypePermissions ) ?? false )
            {
                return false;
            }

            if( !TypePermissions?.Equals( permissions.TypePermissions ) ?? false )
            {
                return false;
            }

            if( !SizePermissions?.Equals( permissions.SizePermissions ) ?? false )
            {
                return false;
            }

            if( !MovementTypePermissions?.Equals( permissions.MovementTypePermissions ) ?? false )
            {
                return false;
            }

            return true;
        }

        public (bool status, String reason) IsValid()
        {
            if( ArchetypePermissions?.Type == PermissionType.White && ArchetypePermissions.Values.Count > 0 )
            {
                if( FactionPermissions?.Values.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Fraktionen gefüllt sein." );
                }
                
                if( TypePermissions?.Values.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Typen gefüllt sein." );
                }

                if( SizePermissions?.Values.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Größen gefüllt sein." );
                }

                if( MovementTypePermissions?.Values.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Bewegungsarten gefüllt sein." );
                }
            }

            return ( true, String.Empty) ;
        }

        public bool Granted( Archetype archetype )
        {
            if( ( !FactionPermissions?.Granted( archetype.Faction ) ?? true )
                ||
                ( !ArchetypePermissions?.Granted( archetype ) ?? true )
                ||
                ( !TypePermissions?.Granted( archetype.Type ) ?? true )
                ||
                ( !SizePermissions?.Granted( archetype.Size ) ?? true )
                ||
                ( !MovementTypePermissions?.Granted( archetype.MovementType ) ?? true ) )
            {
                return false;
            }

            return ( true );
        }

        public string Summary()
        {
            string summary = String.Empty;

            if( FactionPermissions?.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += FactionPermissions.Type == PermissionType.White ? "Erlaubte Fraktionen: " : "Verbotene Fraktionen: ";
                summary += String.Join( ", ", FactionPermissions.Values.Select( x => x.Name ) );
            }

            if( ArchetypePermissions?.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += ArchetypePermissions.Type == PermissionType.White ? "Erlaubte Archetypen: " : "Verbotene Archetypen: ";
                summary += String.Join( ", ", ArchetypePermissions.Values.Select( x => x.Name ) );
            }

            if( TypePermissions?.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += TypePermissions.Type == PermissionType.White ? "Erlaubte Typen: " : "Verbotene Typen: ";
                summary += String.Join( ", ", TypePermissions.Values.Select( x => x.ToString() ) );
            }

            if( SizePermissions?.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += SizePermissions.Type == PermissionType.White ? "Erlaubte Größen: " : "Verbotene Größen: ";
                summary += String.Join( ", ", SizePermissions.Values.Select( x => x.ToString() ) );
            }

            if( MovementTypePermissions?.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += MovementTypePermissions.Type == PermissionType.White ? "Erlaubte Bewegungsarten: " : "Verbotene Bewegungsarten: ";
                summary += String.Join( ", ", MovementTypePermissions.Values.Select( x => x.ToString() ) );
            }

            return ( summary );
        }

        public PermissionSet<Faction> FactionPermissions;

        public PermissionSet<Archetype> ArchetypePermissions;

        public PermissionSet<Archetype.EType> TypePermissions;

        public PermissionSet<Archetype.ESize> SizePermissions;

        public PermissionSet<Archetype.EMovementType> MovementTypePermissions;
    }
}
