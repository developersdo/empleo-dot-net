using Core;
using System;
using Android.Graphics;

namespace Android
{
	public class BitmapResizer : IBitmapResizer<Android.Graphics.Bitmap>
	{
		public Android.Graphics.Bitmap ResizeImageFromResources(object id, int reqWidth, int reqHeight)
		{
			var resourceId = (int) id;

			if(resourceId == 0)
				throw new ArgumentException("id must reference a drawable resource");

			var options = new BitmapFactory.Options
			{
				InJustDecodeBounds = false
			};

			options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);

			return BitmapFactory.DecodeResource(EmpleadoApp.AppContext.Resources, resourceId, options);
		}

		public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			float height = options.OutHeight;
			float width = options.OutWidth;
			double inSampleSize = 1D;

			if (height > reqHeight || width > reqWidth)
			{
				int halfHeight = (int)(height / 2);
				int halfWidth = (int)(width / 2);

				while ((halfHeight / inSampleSize) > reqHeight && (halfWidth / inSampleSize) > reqWidth)
				{
					inSampleSize *= 2;
				}
			}

			return (int)inSampleSize;
		}
	}
}

