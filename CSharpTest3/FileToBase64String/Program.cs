/*
 * 由SharpDevelop创建。
 * 用户： DLAX
 * 日期: 2020/2/17
 * 时间: 17:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;

namespace FileToBase64String
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("请输入文件名称: ");
			var file = Console.ReadLine();
			
			if (string.IsNullOrWhiteSpace(file)) {
				Console.WriteLine("文件名为空！");
			}
			
			if (!File.Exists(file)) {
				Console.WriteLine("文件不存在！");
			}
			
			var bytes = File.ReadAllBytes(file);
			var base64string = Convert.ToBase64String(bytes);
			
			Console.WriteLine(base64string);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}