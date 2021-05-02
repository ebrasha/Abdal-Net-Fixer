using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
 

namespace Abdal_Net_Fixer_AntiProccess
{
    class AntiProccess
    {
		public void ProccessFinder()
		{

		 



			string[] DangerProccessNameArray = {
				 "chrome",
				"firefox"

				};


			foreach (var DangerProccessName in DangerProccessNameArray)
			{

				new Thread(() =>
				{
					Regex regex = new Regex(@"" + DangerProccessName + ".*");
					foreach (Process p in Process.GetProcesses("."))
					{


						//Anti Copy By Proccess Name
						if (regex.Match(p.ProcessName.ToLower()).Success)
						{
							p.Kill();
						}

					}

				}).Start();


			}




		}
	}
}
