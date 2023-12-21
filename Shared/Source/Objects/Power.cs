using System;
using static Universalis.Power;

namespace Universalis
{
    public class Power
    {
        public Power() { }

        public Power( Power power )
        {
            Set( power );
        }

        public void Set( Power power )
        {
            if( null == power )
            {
                throw new ArgumentNullException( nameof( power ) );
            }

            Active = power.Active;
            Name = power.Name;
            Description = power.Description;
            AP = power.AP;
            Target = power.Target;
            Range = power.Range;
            DamageApplication = power.DamageApplication;
            DamageValue = power.DamageValue;
            Duration = power.Duration;
            Rules = power.Rules;
        }

        public bool Equals( Power power )
        {
            if( null == power )
            {
                throw new ArgumentNullException( nameof( power ) );
            }

            if( Active != power.Active
                ||
                Name != power.Name
                ||
                Description != power.Description
                ||
                AP != power.AP
                ||
                Target != power.Target
                ||
                Range != power.Range
                ||
                DamageApplication != power.DamageApplication
                ||
                DamageValue != power.DamageValue
                ||
                Duration != power.Duration
                ||
                Rules != power.Rules)
            {
                return false;
            }

            return true;
        }

        public Guid ID
        {
            get;
            set;
        } = Guid.NewGuid();

        public bool Active
        {
            get;
            set;
        } = true;

        public string Name
        {
            get;
            set;
        } = "Bitte Namen eingeben";

        public string Rules
        {
            get;
            set;
        } = String.Empty;

        public string Description
        {
            get;
            set;
        } = String.Empty;
        public uint AP
        {
            get;
            set;
        } = 0;

        public ETarget Target
        {
            get;
            set;
        } = ETarget.Bereich;

        public ERange Range
        {
            get;
            set;
        } = ERange.Distanz;

        public EDamageApplication DamageApplication
        {
            get;
            set;
        } = EDamageApplication.Keinen;

        public uint DamageValue
        {
            get;
            set;
        } = 0;

        public EDuration Duration
        {
            get;
            set;
        } = EDuration.Sofort;

        /* TODO
         * Attribute
         * Modifier
         * HP loss
         */

        #region enums
        public enum ETarget
        {
            Bereich = 1,
            Modell = 2,
            Nutzer = 3,
        }

        public enum ERange
        {
            Distanz = 1,
            Berührung = 2,
        }

        public enum EDuration
        {
            Sofort = 1,
            Dauerhaft = 2
        }

        public enum EDamageApplication
        {
            Keinen = 1,
            Misserfolg = 2,
            Automatisch = 3,
        }

        #endregion enums
    }
}
