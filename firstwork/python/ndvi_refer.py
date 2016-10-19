# -*- coding: utf-8 -*-
def getdata(row,col,a,ignoredata,invalidata):    #getdata函数表示获得第一次筛选后数据有效值的平均值
    data01=[]
    for ai in a:
        data01.append(ai[row][col])
    # data01=[a1[row][col],a2[row][col],a3[row][col],a4[row][col],a5[row][col],a6[row][col],a7[row][col]]   #row，col分别表示行列号；a1……a7分别表示数据文件
    data02=[]                                #设置一个空列表
    for m in range(len(data01)):
        if data01[m]!=ignoredata:                  #-3000设置，表示为忽略值的设置
            data02.append(data01[m])

    if len(data02)!=0:
        mean01=1.0*sum(data02)/len(data02)         #求取第一次筛选后数据有效值的平均值
    else:
        mean01=invalidata                         #-3000在该函数中为无效值
    return mean01

def IsSubString(SubStrList,Str):
    flag=True
    for substr in SubStrList:
        if not (substr in Str):
            flag=False

    return flag

def GetFileList(FindPath,FlagStr=[]):          #该函数的作用是创建文件列表
    import os
    FileList=[]
    FileNames=os.listdir(FindPath)
    if (len(FileNames)>0):
        for fn in FileNames:
            if (len(FlagStr)>0):
                if (IsSubString(FlagStr,fn)):
                    fullfilename=os.path.join(FindPath,fn)
                    FileList.append(fullfilename)

    if (len(FileNames)>0):
        FileList.sort()

    return FileList



from GetTiff import Tiff
import numpy as np
import sys
try:
    filename=sys.argv[0]
    inputdata=sys.argv[1:]
except:
    inputdata = "U"
# start=time.clock()
#
# flagste01=['.tif']
#
# ndvilist=GetFileList("E:\\wangxc20160912\\secondndvidata",flagste01)
def ndvirefer(ndvilist,output,ignoredata,invalidata):
    # try:
    print ndvilist

    A=Tiff()     #调用读写栅格类文件
    ndvi=[]
    for ndvidata in ndvilist:
        ndvi.append(A.read_tif(ndvidata))
    # ndvi01=A.read_tif(ndvilist[0])
    # ndvi02=A.read_tif(ndvilist[1])
    # ndvi03=A.read_tif(ndvilist[2])
    # ndvi04=A.read_tif(ndvilist[3])
    # ndvi05=A.read_tif(ndvilist[4])
    # ndvi06=A.read_tif(ndvilist[5])
    # ndvi07=A.read_tif(ndvilist[6])    #将2001-2007年ndvi栅格数据文件读取
    NDVI=[]
    for NDVIDATA in ndvi:
        NDVI.append(NDVIDATA[2])
    # NDVI01=ndvi01[2]
    # NDVI02=ndvi02[2]
    # NDVI03=ndvi03[2]
    # NDVI04=ndvi04[2]
    # NDVI05=ndvi05[2]
    # NDVI06=ndvi06[2]
    # NDVI07=ndvi07[2]

    tuple01=NDVI[0].shape        #将数据的行列号赋值给tuple01

    row01=tuple01[0]         #取出数据的行数，赋值给row
    col01=tuple01[1]         #取出数据的行数，赋值给col

    meandata01=np.zeros((row01,col01),dtype=np.int16)    #创建一个大小相同，数值全为0的数组，以便用来存储第一次的ndvi平均值数据
    for i in range(row01):
        for j in range(col01):
            mat01=getdata(i,j,NDVI,ignoredata,invalidata)
            meandata01[i][j]=mat01

    A.write_tif(output,ndvi[0][0],ndvi[1][1],meandata01)    #写栅格数据文件

    print "ok"
    # except:
    #     print "fail"

ndvirefer(inputdata[:-3],inputdata[-1],inputdata[-3],inputdata[-2])