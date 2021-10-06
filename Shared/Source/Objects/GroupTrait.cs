using Newtonsoft.Json;
using System;

namespace Universalis
{
    public class GroupTrait
    {
        public GroupTrait()
        { }

        public GroupTrait( GroupTrait groupTrait )
        {
            Set( groupTrait );
        }

        public bool Equals( GroupTrait groupTrait )
        {
            if( null == groupTrait )
            {
                throw new ArgumentNullException( nameof( groupTrait ) );
            }

            if( Active != groupTrait.Active
                ||
                Name != groupTrait.Name
                ||
                Description != groupTrait.Description
                ||
                Rules != groupTrait.Rules
                ||
                PointsPerModel != groupTrait.PointsPerModel )
            {
                return ( false );
            }

            return ( true );
        }

        public void Set( GroupTrait groupTrait )
        {
            if( null == groupTrait )
            {
                throw new ArgumentNullException( nameof( groupTrait ) );
            }

            Active = groupTrait.Active;

            Name = groupTrait.Name;
            Description = groupTrait.Description;
            Rules = groupTrait.Rules;
            PointsPerModel = groupTrait.PointsPerModel;
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
        }

        public string Description
        {
            get;
            set;
        }

        public string Rules
        {
            get;
            set;
        }

        public int PointsPerModel
        {
            get;
            set;
        }

        public int Points( int modelCount )
        {
            return ( PointsPerModel * modelCount );
        }
    }
}
