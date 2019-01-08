import json
import yaml
import sys

# config
savePath = "D:\combined_scores.json"
localLeaderBoardsDataPathOne = "D:\LocalLeaderboardsOne.dat"
localLeaderBoardsDataPathTwo = "D:\LocalLeaderboardsTwo.dat"

if len(sys.argv) == 2:
    savePath = sys.argv[1]
if len(sys.argv) == 3:
    localLeaderBoardsDataPathOne = sys.argv[2]
if len(sys.argv) == 4:
    localLeaderBoardsDataPathTwo = sys.argv[3]

# main function
def CombineScores():
    try:
        with open(localLeaderBoardsDataPathOne) as f:
            dataOne = json.load(f)
            f.close()
        with open(localLeaderBoardsDataPathTwo) as f:
            dataTwo = json.load(f)
            f.close()
    except FileNotFoundError:
        print("The current localLeaderBoardsDataPaths: "+localLeaderBoardsDataPathOne+" or "+localLeaderBoardsDataPathTwo+" do not exist yet.")
    except Exception:
        print("An Unknown error occured, make sure you have the rights to write/read from file "+localLeaderBoardsDataPathOne+" or "+localLeaderBoardsDataPathTwo+
                                                                                                              ", try starting the program as an Administrator.")

    #de-unicode json by converting to yaml and back
    jsonDump = json.dumps(dataOne)
    jsonDataOne = yaml.safe_load(jsonDump)
    maxlengthOne = jsonDataOne["_leaderboardsData"].__len__()

    # TODO needs a huge refactor below @ptr
    jsonDump = json.dumps(dataTwo)
    jsonDataTwo = yaml.safe_load(jsonDump)
    maxlengthTwo = jsonDataTwo["_leaderboardsData"].__len__()
    # print(maxlengthOne, maxlengthTwo)
    combinedJsonList = []
    x = 0
    y = 0
    try:
        while x <= maxlengthOne:
            x += 1
            for score in jsonDataOne["_leaderboardsData"][x]["_scores"]:
                score['_leaderboardId'] = jsonDataOne["_leaderboardsData"][x]["_leaderboardId"]
                score['_fullCombo'] = str(score['_fullCombo']).upper()
                combinedJsonList.append(score)

    except IndexError:
        #print("Found "+str(x)+" scores in "+localLeaderBoardsDataPathOne)
        try:
            while y <= maxlengthTwo:
                y += 1
                for score in jsonDataTwo["_leaderboardsData"][y]["_scores"]:
                    score['_leaderboardId'] = jsonDataOne["_leaderboardsData"][y]["_leaderboardId"]
                    score['_fullCombo'] = str(score['_fullCombo']).upper()
                    combinedJsonList.append(score)
        except IndexError:
            #print("Found " + str(y) + " scores in " + localLeaderBoardsDataPathTwo)
            pass

    for score in combinedJsonList:
        unicodeId = score['_leaderboardId']
        score['_leaderboardId'] = str(unicodeId.encode('ascii', 'ignore').decode('ascii'))
        if not str(score['_leaderboardId'])[32:] == "":
            score['_leaderboardId'] = str(score['_leaderboardId'])[32:]

    try:
        with open(savePath, "r+") as f:
            f.write(str(combinedJsonList))
            f.close()
            # print("Scores were saved to "+savePath)
    except FileNotFoundError:
        print("The given savePath "+savePath+" does not exist yet")
    except Exception:
        print("An Unknown error occured, make sure you have the rights to write/read from file "+savePath+", try starting the program as Administrator.")
    print(combinedJsonList)

CombineScores()