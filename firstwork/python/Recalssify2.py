# -*- coding: utf-8 -*-
from osgeo import gdal
import sys
try:
    filename=sys.argv[0]
    filedata=sys.argv[1]
    output=sys.argv[2]
    numdata=sys.argv[3:]


except:
	filedata = ""
	output = ""
	numdata = ""
def reclassfy(filedata,output,numdata):
	# filename="e:\\work\\共享杯\\wangxc20160912\\cqa_data\\tqa2008.tif"
	print numdata
	driver = gdal.GetDriverByName("GTiff")
	file = gdal.Open(filedata)
	band = file.GetRasterBand(1)
	lista = band.ReadAsArray()
	# interal=[200,400,600,800]
	# newvalue=[1,2,3,4]
	interal=[]
	newvalue=[]
	for i in range(len(numdata)/2+1):
		interal.append(float(numdata[i]))
	for j in range(len(numdata)/2+1,len(numdata),1):
		newvalue.append(float(numdata[j]))
	print interal
	print newvalue
	# maxvalue=max(lista)
	# minvalue=min(lista)
	# interal.insert(0,minvalue)
	# interal.append(maxvalue)
	for j in  range(file.RasterXSize):
		for i in  range(file.RasterYSize):
			for v in range(len(interal)-1):
				if (lista[i,j] <= interal[v+1] and lista[i,j] >= interal[v]):
					lista[i,j] = newvalue[v]


	# create new file
	# file2 = driver.Create("re.tif", file.RasterXSize, file.RasterYSize, 1)
	file2 = driver.Create(output, file.RasterXSize , file.RasterYSize , 1)
	file2.GetRasterBand(1).WriteArray(lista)

	# spatial ref system
	proj = file.GetProjection()
	georef = file.GetGeoTransform()
	file2.SetProjection(proj)
	file2.SetGeoTransform(georef)
	file2.FlushCache()
	print "ok"
reclassfy(filedata,output,numdata)