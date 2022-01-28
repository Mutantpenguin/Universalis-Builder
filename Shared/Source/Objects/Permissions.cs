using System;
using System.Collections.Generic;
using System.Linq;

namespace Universalis
{
    public enum EPermissionType
    {
        None,
        White,
        Black
    }

    public class PermissionSet<T>
    {
        public PermissionSet()
        {}

        public PermissionSet( EPermissionType type )
        {
            Type = type;
        }

        public PermissionSet( PermissionSet<T> permissionSet )
        {
            Set( permissionSet );
        }

        public EPermissionType Type = EPermissionType.None;

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
                    case EPermissionType.White:
                        return Values.Contains( value );

                    case EPermissionType.Black:
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

        public bool IsValid()
        {
            switch( Type )
            {
                case EPermissionType.None:
                    return Values.Count == 0;

                default:
                    return Values.Count >= 0;
            }
        }
    }

    public class Permissions
    {
        public static readonly IList<EPermissionType> EPermissionTypeList = Enum.GetValues( typeof( EPermissionType ) ).Cast<EPermissionType>().ToList().AsReadOnly();

        public Permissions()
        { }

        public Permissions( Permissions permissions )
            : this()
        {
            Set( permissions );
        }
        public void Set( Permissions permissions )
        {
            Faction = new PermissionSet<Faction>( permissions.Faction );

            Archetype = new PermissionSet<Archetype>( permissions.Archetype );

            Type = new PermissionSet<Archetype.EType>( permissions.Type );

            Size = new PermissionSet<Archetype.ESize>( permissions.Size );

            MovementType = new PermissionSet<Archetype.EMovementType>( permissions.MovementType );
        }

        public bool Equals( Permissions permissions )
        {
            if( null == permissions )
            {
                throw new ArgumentNullException( nameof( permissions ) );
            }

            if( !Faction.Equals( permissions.Faction ) )
            {
                return false;
            }

            if( !Archetype.Equals( permissions.Archetype ) )
            {
                return false;
            }

            if( !Type.Equals( permissions.Type ) )
            {
                return false;
            }

            if( !Size.Equals( permissions.Size ) )
            {
                return false;
            }

            if( !MovementType.Equals( permissions.MovementType ) )
            {
                return false;
            }

            return true;
        }

        public (bool status, String reason) IsValid()
        {
            if( !Faction.IsValid()
                ||
                !Archetype.IsValid()
                ||
                !Type.IsValid()
                ||
                !Size.IsValid()
                ||
                !MovementType.IsValid() )
            {
                return (false, "TODO");
            }

            if( Archetype.Type == EPermissionType.White && Archetype.Values.Count > 0 )
            {
                if( Faction.Values.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Fraktionen gefüllt sein." );
                }
                
                if( Type.Values.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Typen gefüllt sein." );
                }

                if( Size.Values.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Größen gefüllt sein." );
                }

                if( MovementType.Values.Count > 0 )
                {
                    return ( false, "Bei gefüllter Whitelist für Archetypen darf nicht gleichzeitig die White- oder Blacklist für Bewegungsarten gefüllt sein." );
                }
            }

            return ( true, String.Empty) ;
        }

        public bool Granted( Archetype archetype )
        {
            if( !Faction.Granted( archetype.Faction )
                ||
                !Archetype.Granted( archetype )
                ||
                !Type.Granted( archetype.Type )
                ||
                !Size.Granted( archetype.Size )
                ||
                !MovementType.Granted( archetype.MovementType ) )
            {
                return false;
            }

            return ( true );
        }

        public string Summary()
        {
            string summary = String.Empty;

            if( Faction.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += Faction.Type == EPermissionType.White ? "Erlaubte Fraktionen: " : "Verbotene Fraktionen: ";
                summary += String.Join( ", ", Faction.Values.Select( x => x.Name ) );
            }

            if( Archetype.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += Archetype.Type == EPermissionType.White ? "Erlaubte Archetypen: " : "Verbotene Archetypen: ";
                summary += String.Join( ", ", Archetype.Values.Select( x => x.Name ) );
            }

            if( Type.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += Type.Type == EPermissionType.White ? "Erlaubte Typen: " : "Verbotene Typen: ";
                summary += String.Join( ", ", Type.Values.Select( x => x.ToString() ) );
            }

            if( Size.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += Size.Type == EPermissionType.White ? "Erlaubte Größen: " : "Verbotene Größen: ";
                summary += String.Join( ", ", Size.Values.Select( x => x.ToString() ) );
            }

            if( MovementType.Values.Count > 0 )
            {
                summary += String.IsNullOrEmpty( summary ) ? "" : Environment.NewLine;
                summary += MovementType.Type == EPermissionType.White ? "Erlaubte Bewegungsarten: " : "Verbotene Bewegungsarten: ";
                summary += String.Join( ", ", MovementType.Values.Select( x => x.ToString() ) );
            }

            return ( summary );
        }

        public PermissionSet<Faction> Faction = new PermissionSet<Faction>();

        public PermissionSet<Archetype> Archetype = new PermissionSet<Archetype>();

        public PermissionSet<Archetype.EType> Type = new PermissionSet<Archetype.EType>();

        public PermissionSet<Archetype.ESize> Size = new PermissionSet<Archetype.ESize>();

        public PermissionSet<Archetype.EMovementType> MovementType = new PermissionSet<Archetype.EMovementType>();
    }
}
