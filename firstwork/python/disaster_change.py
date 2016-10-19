# -*- coding: utf-8 -*-

from GetTiff import Tiff
import numpy as np
import sys
import os
try:
    filename=sys.argv[0]
    disasterdata=sys.argv[1]
    ndvirefer=sys.argv[2]
    ignoredata=sys.argv[3]
    invalidata=sys.argv[4]
    outdata=sys.argv[5]

except:
    disasterdata = ""
    ndvirefer = ""
    outdata = ""

def disasterchange(disasterdata,ndvirefer,ignoredata,invalidata,outdata):
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
        disaster = A.read_tif(disasterdata)
        ndvireferdata = A.read_tif(ndvirefer)
        DisasterData = disaster[2]
        NdviRefer = ndvireferdata[2]

        tuple01 = DisasterData.shape

        row01 = tuple01[0]
        col01 = tuple01[1]

        disasterchange = np.zeros((row01, col01), dtype=np.int16)

        for i in range(row01):
            for j in range(col01):
                if DisasterData[i][j] != ignoredata:
                    if NdviRefer[i][j] != ignoredata:
                        disasterchange[i][j] = NdviRefer[i][j] - DisasterData[i][j]
                    else:
                        disasterchange[i][j] = invalidata
                else:
                    disasterchange[i][j] = invalidata
        A.write_tif(outdata, disaster[0], disaster[1],disasterchange)
        # A.write_tif("E:\\wangxc20160912\\disaster_change\\disasterchange.tif", disasterdata[0], disasterdata[1],
        #             disasterchange)
        print "ok"
    except:
        print "fail"
disasterchange(disasterdata,ndvirefer,ignoredata,invalidata,outdata)