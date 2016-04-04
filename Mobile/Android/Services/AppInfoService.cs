using System;
using Android.Content;
using Android.Content.PM;

namespace Android
{

	public class AppInfoService : IAppInfoService
	{
		Context _context;

		PackageInfo _packageInfo;

		public int CodeVersion {
			get {
				return _packageInfo.VersionCode;
			}
		}

		public string VersionName {
			get {
				return _packageInfo.VersionName;
			}
		}

		public AppInfoService (IContextService contextService)
		{
			_context = (Context) contextService.GetContext();

			_packageInfo = _context.PackageManager.GetPackageInfo (_context.PackageName, 0);
		}
	}
}
