# -*- coding: utf-8 -*-
from GetTiff import Tiff
import numpy as np
import sys
import os

try:
    filename=sys.argv[0]
    disasterdata=sys.argv[1]
    ndvirefer=sys.argv[2]
    invalidata=sys.argv[3]
    ignoredata=sys.argv[4]
    a=sys.argv[5]
    b=sys.argv[6]
    c=sys.argv[7]
    outdata=sys.argv[8]
except:
    disasterdata = ""
    ndvirefer = ""
    outdata = ""
    a = -1  # a表示受灾值
    b = 0  # b表示未受灾值
    c = 200  # c表示为人工设置的受灾阈值

def Dvalue(disasterdata,ndvirefer,invalidata,ignoredata,a,b,c,outdata):
    try:
        if os.path.exists(disasterdata) == False:
            print "数据文件不存在"
            return
        if os.path.exists(ndvirefer) == False:
            print "筛选文件不存在"
            return
        A = Tiff()

        # disasterdata = A.read_tif("E:\\wangxc20160912\\fcndvidata\\ftndvi2008.tif")
        # ndvirefer = A.read_tif("E:\\wangxc20160912\\secondndvimean\\secondndvimean.tif")
        disasterdata = A.read_tif(disasterdata)
        ndvirefer = A.read_tif(ndvirefer)
        DisasterData = disasterdata[2]
        NdviRefer = ndvirefer[2]

        tuple01 = DisasterData.shape

        row01 = tuple01[0]
        col01 = tuple01[1]

        # a = -1  # a表示受灾值
        # b = 0  # b表示未受灾值
        # c = 200  # c表示为人工设置的受灾阈值

        disasterjudge = np.zeros((row01, col01), dtype=np.int16)

        for i in range(row01):
            for j in range(col01):
                if DisasterData[i][j] != ignoredata:
                    if NdviRefer[i][j] != ignoredata:
                        D_value = NdviRefer[i][j] - DisasterData[i][j]
                        if D_value >= c:
                            disasterjudge[i][j] = a
                        else:
                            disasterjudge[i][j] = b
                    else:
                        disasterjudge[i][j] = invalidata
                else:
                    disasterjudge[i][j] = invalidata
        A.write_tif(outdata, disasterdata[0], disasterdata[1],disasterjudge)
        # A.write_tif("E:\\wangxc20160912\\D_value\\dvalue_result.tif", disasterdata[0], disasterdata[1], disasterjudge)

        print "ok"
    except:
        print "fail"

Dvalue(disasterdata,ndvirefer,invalidata,ignoredata,a,b,c,outdata)
