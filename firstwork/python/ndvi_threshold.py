# -*- coding: utf-8 -*-

from GetTiff import Tiff
import numpy as np
import sys
import os
try:
    filename=sys.argv[0]
    disasterdata=sys.argv[1]
    normaldata=sys.argv[2]
    ignoredata=sys.argv[3]
    invalidata=sys.argv[4]
    a = sys.argv[5]
    b = sys.argv[6]
    output=sys.argv[7]

except:
    disasterdata = ""
    normaldata = ""
    ignoredata = ""
    invalidata = ""
    a = ""
    b = ""
    output = ""
def ndvithres(disasterdata,normaldata,ignoredata,invalidata,a,b,output):
    A=Tiff()

    # disasterchange=A.read_tif("E:\\wangxc20160912\\disaster_change\\disasterchange.tif")
    # normalchange=A.read_tif("E:\\wangxc20160912\\normal_change\\normalchange.tif")

    disasterchange = A.read_tif(disasterdata)
    normalchange = A.read_tif(normaldata)

    Dchange=disasterchange[2]
    Nchange=normalchange[2]

    tuple01=Dchange.shape

    row01=tuple01[0]
    col01=tuple01[1]

    disasterjudge=np.zeros((row01,col01),dtype=np.int16)
    # a=0                 #a表示为未受灾
    # b=-1                #b表示为受灾，-3000表示为无效值或忽略值

    for i in range(row01):
        for j in range(col01):
            if Dchange[i][j]!=ignoredata:
                if Nchange[i][j]!=ignoredata:
                    if Dchange[i][j]>Nchange[i][j]:
                        disasterjudge[i][j]=b
                    else:
                        disasterjudge[i][j]=a
                else:
                    disasterjudge[i][j]=invalidata
            else:
                disasterjudge[i][j]=invalidata
    # E:\\wangxc20160912\\ndvi_threshold\\ndvi_threshold.tif
    A.write_tif(output,disasterchange[0],disasterchange[1],disasterjudge)

    print "ok"

ndvithres(disasterdata,normaldata,ignoredata,invalidata,a,b,output)