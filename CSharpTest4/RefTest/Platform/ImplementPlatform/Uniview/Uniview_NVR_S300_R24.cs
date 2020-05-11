using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefTest.Platform.ImplementPlatform.Uniview
{
    public class Uniview_NVR_S300_R24 : BasePlatform
    {
        public override PlatformResult<PersonList> AddPersonList(PersonList list)
        {
            var result = new PlatformResult<PersonList>()
            {
                Status = true,
                Message = "成功",
                Data = new PersonList()
            };

            Console.WriteLine($"{nameof(Uniview_NVR_S300_R24)}.{nameof(AddPersonList)} function invoke.");
            return result;
        }

        public override PlatformResult<TargetPerson> AddTargetPerson(TargetPerson person)
        {
            throw new NotImplementedException();
        }

        public override PlatformResult<PersonList> DeletePersonList(PersonList list)
        {
            throw new NotImplementedException();
        }

        public override PlatformResult<TargetPerson> DeleteTargetPerson(TargetPerson person)
        {
            throw new NotImplementedException();
        }

        public override PlatformResult<PersonList> UpdatePersonList(PersonList list)
        {
            throw new NotImplementedException();
        }

        public override PlatformResult<TargetPerson> UpdateTargetPerson(TargetPerson person)
        {
            throw new NotImplementedException();
        }
    }
}
