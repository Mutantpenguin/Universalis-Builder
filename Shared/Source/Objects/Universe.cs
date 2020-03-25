using System;

namespace Universalis
{
    public class Universe
    {
        public Universe() { }

        public Universe( Universe universe )
        {
            Set( universe );
        }

        public void Set( Universe universe )
        {
            if( null == universe )
            {
                throw new ArgumentNullException( nameof( universe ) );
            }

            Name = universe.Name;
            Description = universe.Description;
        }

        public bool Equals( Universe universe )
        {
            if( null == universe )
            {
                throw new ArgumentNullException( nameof( universe ) );
            }

            if( Name != universe.Name
                ||
                Description != universe.Description )
            {
                return ( false );
            }

            return ( true );
        }

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
    }
}