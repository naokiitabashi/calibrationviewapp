# coding: UTF-8
import sys
sys.path.append(r'c:/Program Files /IronPython 2.7')
sys.path.append(r'c:/Program Files /IronPython 2.7/DLLs')
sys.path.append(r'c:/Program Files /IronPython 2.7/Lib')
sys.path.append(r'c:/Program Files /IronPython 2.7/Lib/site-packages')
import requests
import json
import math
from msvcrt import getch

class ViewCount():

    USER_ID = 'OKsaiyowa'
    PER_PAGE = 20
    allViews = 0

    headers = {"content-type": "application/json",
            'Authorization': 'Bearer API key'}

    #Send a request and insert a json that includes the total number of posts
    url = 'https://qiita.com/api/v2/users/' + USER_ID
    res = requests.get(url, headers=headers)
    json_qiita_info = res.json()

    #Pull out the number of posts from json
    items_count = json_qiita_info['items_count']

    #Calculate the number of pages
    page = items_count / PER_PAGE

    def count(self):
        
        info_list = list()
        info_list.append('|Article title|Number of views|Like count|')

        #Get all posted articles
        for i in range(int(self.page) + 1):

            #Send a request and insert a json containing the information of each article
            url = 'https://qiita.com/api/v2/authenticated_user/items' + \
                '?page=' + str(i + 1)
            res = requests.get(url, headers=self.headers)
            json_qiita_info = res.json()

            for j in range(self.PER_PAGE):
                try:
                    #Pull ID out of json
                    item_id = json_qiita_info[j]['id']

                    #Send a request and insert a json containing the number of views of the article with the specified ID
                    url = 'https://qiita.com/api/v2/items/' + str(item_id)
                    res = requests.get(url, headers=self.headers)
                    json_view = res.json()

                    #Pull out the number of views from json
                    page_view = json_view['page_views_count']

                    #Addition and substitution to make the total number of views
                    self.allViews += page_view

                    #Display in order of title, number of likes, number of views
                    info_list.append('| ' + json_qiita_info[j]['title'] + ' | ' +
                        str(json_qiita_info[j]['likes_count']) + ' |' +
                        str(page_view) + ' |')

                except IndexError:
                    info_list.append('View total:' + str(self.allViews))
                    #new line
                    info_list = "\n".join(info_list)
                    return info_list
                
        #Output with line break
        info_list = "\n".join(info_list)
        return info_list

#for test
v = ViewCount()
print(v.count())



