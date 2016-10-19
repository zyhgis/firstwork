# -*- coding: utf-8 -*-
from osgeo import gdal
# import numpy as np
import chardet
import os.path
class Tiff:
	def read_tif(self,filename):
		# filename=filename.decode('gbk').encode('utf-8')
		# print isinstance(filename,basestring)
		# filename=unicode(filename).unicode("UTF-8")
		# filename.decode("GB2312")
		# filename=filename.decode('iso-8859-2').encode('utf8')
		# filename="e:\\work\\共享杯\\wangxc20160912\\cqa_data\\tqa2008.tif";
		# print chardet.detect(filename)
		# # print isinstance(filename, basestring)
		# if os.path.exists(filename)==False:
		# 	return filename+"不存在"
		print filename+"gettiff"
		gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO")
		dataset=gdal.Open(filename)
		im_width=dataset.RasterXSize
		im_height=dataset.RasterYSize
		im_bands=dataset.RasterCount

		im_geotrans=dataset.GetGeoTransform()
		im_proj=dataset.GetProjection()
		im_data=dataset.ReadAsArray(0,0,im_width,im_height)

		del dataset

		return im_proj,im_geotrans,im_data


	def write_tif(self,filename,im_proj,im_geotrans,im_data):
		if 'int8' in im_data.dtype.name:
			datatype=gdal.GDT_Byte
		elif 'int16' in im_data.dtype.name:
			datatype=gdal.GDT_Int16
		else:
			datatype=gdal.GDT_Float32
		# print im_data.shape
		if len(im_data.shape)==3:
			im_bands,im_height,im_width=im_data.shape
		else:
			im_bands,(im_height,im_width)=1,im_data.shape

		driver=gdal.GetDriverByName("GTiff")
		dataset=driver.Create(filename,im_width,im_height,im_bands,datatype)

		dataset.SetGeoTransform(im_geotrans)
		dataset.SetProjection(im_proj)

		if im_bands==1:
			dataset.GetRasterBand(1).WriteArray(im_data)
		else:
			for i in range(im_bands):
				dataset.GetRasterBand(i+1).WriteArray(im_data[i])

		del dataset