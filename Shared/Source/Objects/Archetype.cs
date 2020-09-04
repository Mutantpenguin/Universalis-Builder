using Newtonsoft.Json;
using System;

namespace Universalis
{
    public class Archetype
    {
        public Archetype() {}

        public Guid ID
        {
            get;
            set;
        } = Guid.NewGuid();

        public string Name
        {
            get;
            set;
        } = "Bitte Namen eingeben";

        public string Description
        {
            get;
            set;
        } = "Bitte Beschreibung eingeben";

        [JsonConverter( typeof( JsonFactionConverter ) )]
        public Faction Faction
        {
            get;
            set;
        }
    }
}
