# -*- coding: utf-8 -*-

def datalist(row,col,a):       #函数datalist用于构建同一像元的
    data01=[]
    for data in a:
        data01.append(data[row][col])
    # data01=[a1[row][col],a2[row][col],a3[row][col],a4[row][col],a5[row][col],a6[row][col],a7[row][col]]
    return data01

def normalchange(data02,secondndvimean,ignoredata,invilidata):
    a=[]
    if len(data02)!=0:
        for i in range(len(data02)):
            if data02[i]!=ignoredata:
                b=abs(data02[i]-secondndvimean)
                a.append(b)
        max01=max(a)
    else:
        max01=invilidata
    return max01


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
import time
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
def normalchangemain(ndvilist,referdata,ignoredata,invalidata,output):
    # ndvilist=[]
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
    ndvirefer=A.read_tif(referdata)     #读取
    print "zhang"
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
    NdviRefer=ndvirefer[2]
    tuple01=NDVI[0].shape        #将数据的行列号赋值给tuple01

    row01=tuple01[0]         #取出数据的行数，赋值给row
    col01=tuple01[1]         #取出数据的行数，赋值给col

    meandata02=np.zeros((row01,col01),dtype=np.int16)    #创建一个大小相同，数值全为0的数组，以便用来存储第一次的ndvi平均值数据

    for i in range(row01):
        for j in range(col01):
            if NdviRefer[i][j]!=ignoredata:
                Datalist01=datalist(i,j,NDVI)
                NormalChange=normalchange(Datalist01,NdviRefer[i][j],ignoredata,invalidata)
                meandata02[i][j]=NormalChange
            else:
                meandata02[i][j]=invalidata
    print output
    A.write_tif(output,ndvi[0][0],ndvi[0][1],meandata02)
    print "ok"
normalchangemain(inputdata[:-4],inputdata[-4],inputdata[-3],inputdata[-2],inputdata[-1])






