# -*- coding: utf-8 -*-

from GetTiff import Tiff
import numpy as np
import sys
try:
    filename=sys.argv[0]
    disasterdata=sys.argv[1]
    normalchangedata=sys.argv[2]
    ignoredata=sys.argv[3]
    invalidata=sys.argv[4]
    output=sys.argv[5]

except:
    disasterdata = ""
    normalchangedata = ""
    ignoredata = ""
    invalidata = ""
    output = ""
def imagethres(disasterdata,normalchangedata,ignoredata,invalidata,output):
    A=Tiff()
    # disasterchange = A.read_tif("E:\\wangxc20160912\\disaster_change\\disasterchange.tif")
    # normalchange = A.read_tif("E:\\wangxc20160912\\normal_change\\normalchange.tif")

    disasterchange=A.read_tif(disasterdata)
    normalchange=A.read_tif(normalchangedata)

    Dchange=disasterchange[2]
    Nchange=normalchange[2]

    tuple01=Dchange.shape

    row01=tuple01[0]
    col01=tuple01[1]

    assessment=np.zeros((row01,col01),dtype=np.float32)

    for i in range(row01):
        for j in range(col01):
            if Dchange[i][j]!=ignoredata:
                if Nchange[i][j]!=ignoredata:
                    if Nchange[i][j]!=0:
                        assessment[i][j]=(1.0*Dchange[i][j])/Nchange[i][j]
                    else:
                        assessment[i][j]=invalidata
                else:
                    assessment[i][j]=invalidata
            else:
                assessment[i][j]=invalidata

    A.write_tif(output,disasterchange[0],disasterchange[1],assessment)
    # A.write_tif("E:\\wangxc20160912\\threshold_ratio\\threshold_ratio.tif", disasterchange[0], disasterchange[1],assessment)

    print "ok"
imagethres(disasterdata,normalchangedata,ignoredata,invalidata,output)





