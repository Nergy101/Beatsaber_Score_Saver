import json
import yaml
import sys

# exe made with pyinstaller --onefile scoresorter.py

# config
savePath = "D:\sorted_scores.json"
localLeaderBoardsDataPath = "D:\LocalLeaderboards.dat"
#python python_script.py var1 var2
#print (sys.argv[0]) # prints python_script.py
#print (sys.argv[1]) # prints var1
#print (sys.argv[2]) # prints var2

# all sys.argv are strings
if len(sys.argv) == 1:
    sortType = 2
if len(sys.argv) == 2:
    sortType = sys.argv[1]
if len(sys.argv) == 3:
    savePath = sys.argv[2]
if len(sys.argv) == 4:
    localLeaderBoardsDataPath = sys.argv[3]

# TODO organize code better @ptr

def sort(type, jsonList):
    if type == 1:
        jsonList.sort(key=lambda row: -row['_score'])
        jsonList.sort(key=lambda row: row["_leaderboardId"])
    if type == 2:
        jsonList.sort(key=lambda row: -row['_score'])
        jsonList.sort(key=lambda row: row["_playerName"])
    if type == 3:
        jsonList.sort(key=lambda row: -row['_leaderboardId'])
        jsonList.sort(key=lambda row: row["_playerName"])


# main function
def SaveScores():
    try:
        with open(localLeaderBoardsDataPath) as f:
            data = json.load(f)
            f.close()
    except FileNotFoundError:
        print("The current localLeaderBoardsDataPath: "+localLeaderBoardsDataPath+" does not exist yet.")
    except Exception:
        print("An Unknown error occured, make sure you have the rights to write/read from file " + localLeaderBoardsDataPath + ""
                                                                                                              ", try starting the program as Administrator.")
    #de-unicode json by converting to yaml and back
    jsonDump = json.dumps(data)
    jsonData = yaml.safe_load(jsonDump)
    maxlength = jsonData["_leaderboardsData"].__len__()

    jsonList = []
    x = 0
    try:
        while x <= maxlength:
            x += 1
            for score in jsonData["_leaderboardsData"][x]["_scores"]:
                score['_leaderboardId'] = jsonData["_leaderboardsData"][x]["_leaderboardId"]
                score['_fullCombo'] = str(score['_fullCombo']).upper()
                jsonList.append(score)
    except IndexError:
        #print("Found "+str(x)+" scores")
        pass

    for score in jsonList:
        unicodeId = score['_leaderboardId']
        score['_leaderboardId'] = str(unicodeId.encode('ascii', 'ignore').decode('ascii'))
        if not str(score['_leaderboardId'])[32:] == "":
            score['_leaderboardId'] = str(score['_leaderboardId'])[32:]

    sort(sortType, jsonList) # type and the list
    #sort(2, jsonList)

    try:
        with open(savePath, "r+") as f:
            f.write(str(jsonList))
            f.close()
    except FileNotFoundError:
        print("The given savePath "+savePath+" does not exist yet")
    except Exception:
        print("An Unknown error occured, make sure you have the rights to write/read from file "+savePath+""
                                                              ", try starting the program as Administrator.")

    #print("Scores were saved to "+savePath)
    print(jsonList)

SaveScores()

