# -*- coding: utf-8 -*-
def judgedata(row,col,meandata,data03,ignoredata,invalidata):      #judgedata函数表示获得第二次筛选后的数据像元值，meandata表示第一次筛选后ndvi平均值
    # print row
    # print col
    # print meandata
    # print data03
    # print ignoredata
    # print invalidata
    if data03[row][col]!=ignoredata:                  #data03表示第一次筛选后各年份ndvi数据
        if meandata[row][col]!=ignoredata:
            if abs(1.0*(data03[row][col]-meandata[row][col])/meandata[row][col])<=0.3:
                data04=data03[row][col]
            else:
                data04=invalidata
        else:
            data04=invalidata
    else:
        data04=invalidata

    return data04                          #data04表示第二次筛选后ndvi数据

from GetTiff import Tiff
import numpy as np
import sys
import os
# sys.path.append(r"E:\work\共享杯\code\firstwork\firstwork\bin\Debug")

try:
    filename=sys.argv[0]
    ndvidata=sys.argv[1]
    meandata=sys.argv[2]
    ignoredata=sys.argv[3]
    invalidata=sys.argv[4]
    outdata=sys.argv[5]
except:
    ndvidata = "E:\\wangxc20160912\\fcndvidata\\ftndvi2007.tif"
    meandata = "E:\\wangxc20160912\\firstndvimean\\firstndvimean.tif"
    ignoredata = -3000
    invalidata = -3000
    outdata = "E:\\wangxc20160912\\tcycz.tif"
    # print result
def secondchoice(ndvidata,meandata,outdata,ignoredata,invalidata):
    # try:
    print "start"
    ignoredata=int(ignoredata)
    invalidata=int(invalidata)
    if os.path.exists(ndvidata) == False:
        print "数据文件不存在"
        return
    if os.path.exists(meandata) == False:
        print "筛选文件不存在"
        return
    A = Tiff()
    # ndvidata = A.read_tif("E:\\wangxc20160912\\fcndvidata\\ftndvi2007.tif")
    # meandata = A.read_tif("E:\\wangxc20160912\\firstndvimean\\firstndvimean.tif")
    ndvi = A.read_tif(ndvidata)
    mean = A.read_tif(meandata)
    print "2"

    NdviData = ndvi[2]
    MeanData = mean[2]

    tuple01 = NdviData.shape  # 将数据的行列号赋值给tuple01

    row01 = tuple01[0]  # 取出数据的行数，赋值给row
    col01 = tuple01[1]  # 取出数据的行数，赋值给col

    data01 = np.zeros((row01, col01), dtype=np.int16)

    # print MeanData

    for i in range(row01):
        for j in range(col01):
            if(MeanData[i][j]==0):
                print i
                print j

    for i in range(row01):
        for j in range(col01):
            data01[i][j] = judgedata(i, j, MeanData, NdviData,ignoredata,invalidata)
    # A.write_tif("sftndvi2007.tif", ndvidata[0], ndvidata[1], data01)
    A.write_tif(outdata, ndvi[0], ndvi[1], data01)
    print "ok"
    # except:
    #     print "fail"

secondchoice(ndvidata,meandata,outdata,ignoredata,invalidata)