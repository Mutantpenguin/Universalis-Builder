using Newtonsoft.Json;
using Source.JsonHelper;
using System;
using System.Collections.Generic;

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

            ID = power.ID;
            Active = power.Active;
            Name = power.Name;
            Description = power.Description;
            Level = power.Level;
            AP = power.AP;
            Attribute = power.Attribute;
            Modifier = power.Modifier;
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

            if( ID != power.ID )
            {
                return false;
            }

            if( Active != power.Active
                ||
                Name != power.Name
                ||
                Description != power.Description
                ||
                Level != power.Level
                ||
                AP != power.AP
                ||
                Attribute != power.Attribute
                ||
                Modifier != power.Modifier
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

        public uint Level
        {
            get;
            set;
        } = 1;

        public uint AP
        {
            get;
            set;
        } = 1;

        [JsonConverter( typeof( JsonEAttributeConverter ) )]
        public EAttribute Attribute
        {
            get;
            set;
        } = EAttribute.AGI;

        public int Modifier
        {
            get;
            set;
        } = 0;

        public ETarget Target
        {
            get;
            set;
        } = ETarget.Beliebig;

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

        #region enums

        public enum EAttribute
        {
            AGI = 1,
            NK = 2,
            FK = 3,
            KO = 4,
            WN = 5,
            EH = 6,
        }

        public static Dictionary<EAttribute, string> AttributeMapping = new Dictionary<EAttribute, string>
        {
            { EAttribute.AGI, "AGI" },
            { EAttribute.NK, "HTH" },
            { EAttribute.FK, "LRC" },
            { EAttribute.KO, "PHY" },
            { EAttribute.WN, "AWA" },
            { EAttribute.EH, "DET" },
        };

        public enum ETarget
        {
            Beliebig = 1,
            Modell = 2,
            Anwender = 3,
        }

        public enum ERange
        {
            Distanz = 1,
            Kontakt = 2,
        }

        public enum EDuration
        {
            Sofort = 1,
            Permanent = 2
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
