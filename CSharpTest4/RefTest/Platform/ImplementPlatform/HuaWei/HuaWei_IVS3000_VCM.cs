﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefTest.Platform.ImplementPlatform.HuaWei
{
    public class HuaWei_IVS3000_VCM : BasePlatform
    {
        public override PlatformResult<PersonList> AddPersonList(PersonList list)
        {
            var result = new PlatformResult<PersonList>()
            {
                Status = true,
                Message = "成功",
                Data = new PersonList()
            };

            Console.WriteLine($"{nameof(HuaWei_IVS3000_VCM)}.{nameof(AddPersonList)} function invoke.");
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
