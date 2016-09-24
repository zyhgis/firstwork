# -*- coding: utf-8 -*-
import sys
sys.path.append(r"E:\work\共享杯\code\firstwork\firstwork\bin\Debug")
from GetTiff import Tiff   #GetTiff是自己编写的一个读写栅格文件的包，Tiff是相应的一个读写栅格类文件
def judgeuse(a):      #该函数主要用以判断QA文件某一数值是否有效
    b=bin(a)           #a表示为QA文件某一像元值；bin（）是十进制与二进制之间的转换函数，但该函数的转换结果是字符串类型的
    c=b.__getslice__(len(b)-2,len(b))    #将字符串类型数据最后两位取出，赋值给c，c为字符串类型数据
    d=int(c)         #转化数据类型，将字符串型数据转化为整数型数据
    f=[10,11]        #根据官方文件说明若QA文件像元值转化为二进制后，最后两位是10或11，则表示该数值无效
    if d in f:
        r01=0        #函数返回值为0，表示无效值
    else:
        r01=1        #函数返回值为1，表示有效值
    return r01
try:
    filename=sys.argv[0]
    dqdata=sys.argv[1]
    ndvidata=sys.argv[2]
    invaliddata=sys.argv[3]
    result=sys.argv[4]
except:
    dqdata = "U"
    ndvidata = "k"
    invaliddata = -3000
    result = "ds"

def qa_choice2(dqdata,ndvidata,invaliddata,result):
    #print "开始"
    A=Tiff()        #调用类文件

    qadata=A.read_tif(dqdata)    #读取QA文件
    ndvidata=A.read_tif(ndvidata)    #读取ndvi原始数据文件

    QaData=qadata[2]       #读取QA数据，并赋给QaData数组
    NdviData=ndvidata[2]   #读取ndvi数据，并赋给NdviData数组

    ##print QaData.shape
    ##print NdviData.shape

    tuple01=QaData.shape    #将数据的行列号赋值给tuple01
    ##print tuple01
    ##print type(tuple01)
    row=tuple01[0]         #取出数据的行数，赋值给row
    col=tuple01[1]         #取出数据的行数，赋值给col

    #print row
    #print col

    NdviData01=NdviData      #将ndvi原始数据赋值给NdviData01数组

    for i in range(row):
        for j in range(col):
            if judgeuse(QaData[i][j])==0:      #判断QA文件中的数据是否有效，0表示无效，若无效，则ndvi数据相对应位置的像元值设置为无效值
                NdviData01[i][j]=invaliddata         #-3000表示为无效值

    A.write_tif(result,ndvidata[0],ndvidata[1],NdviData01)     #将筛选后的ndvi数据重新写为栅格文件

    print "ok"
qa_choice2(dqdata,ndvidata,invaliddata,result)










