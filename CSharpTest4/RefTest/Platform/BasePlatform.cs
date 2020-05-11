using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefTest.Platform
{
    public abstract class BasePlatform
    {
        public abstract PlatformResult<PersonList> AddPersonList(PersonList list);

        public abstract PlatformResult<PersonList> UpdatePersonList(PersonList list);

        public abstract PlatformResult<PersonList> DeletePersonList(PersonList list);

        public abstract PlatformResult<TargetPerson> AddTargetPerson(TargetPerson person);

        public abstract PlatformResult<TargetPerson> UpdateTargetPerson(TargetPerson person);

        public abstract PlatformResult<TargetPerson> DeleteTargetPerson(TargetPerson person);
    }
}
