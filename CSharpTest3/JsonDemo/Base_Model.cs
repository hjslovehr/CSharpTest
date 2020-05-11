using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDemo
{
	public class Base_Model
	{
		/// <summary>
		/// 是否下发
		/// </summary>
		public bool Download
		{
			get;
			set;
		}
		
		public Base_Model()
		{
			Download = true;
		}
	}
}
