# -*- coding: utf-8 -*-

from GetTiff import Tiff
import numpy as np
import sys
try:
    filename=sys.argv[0]
    disasterdata=sys.argv[1]
    ndvirefedata=sys.argv[2]
    ignoredata=sys.argv[3]
    invalidata=sys.argv[4]
    output=sys.argv[5]

except:
    disasterdata = ""
    ndvirefedata = ""
    ignoredata = ""
    invalidata = ""
    output = ""
def imagethres(disasterdata,ndvirefedata,ignoredata,invalidata,output):
    A=Tiff()

    # disasterchange=A.read_tif("E:\\wangxc20160912\\disaster_change\\disasterchange.tif")
    # ndvirefer=A.read_tif("E:\\wangxc20160912\\secondndvimean\\secondndvimean.tif")
    disasterchange=A.read_tif(disasterdata)
    ndvirefer=A.read_tif(ndvirefedata)

    Dchange=disasterchange[2]
    NdviRefer=ndvirefer[2]

    tuple01=Dchange.shape

    row01=tuple01[0]
    col01=tuple01[1]

    assessment=np.zeros((row01,col01),dtype=np.float32)

    for i in range(row01):
        for j in range(col01):
            if Dchange[i][j]!=ignoredata:
                if NdviRefer[i][j]!=ignoredata:
                    assessment[i][j]=(1.0*Dchange[i][j])/NdviRefer[i][j]
                else:
                    assessment[i][j]=invalidata
            else:
                assessment[i][j]=invalidata
    # E:\\wangxc20160912\\image_threshold\\image_threshold.tif
    A.write_tif(output,disasterchange[0],disasterchange[1],assessment)

    print "ok"

imagethres(disasterdata,ndvirefedata,ignoredata,invalidata,output)
