```
1）、cd : 改变目录。
2）、cd . . 回退到上一个目录，直接cd进入默认目录
3）、pwd : 显示当前所在的目录路径。
4）、ls(ll): 都是列出当前目录中的所有文件，只不过ll(两个ll)列出的内容更为详细。
5）、touch : 新建一个文件 如 touch index.js 就会在当前目录下新建一个index.js文件。
6）、rm: 删除一个文件, rm index.js 就会把index.js文件删除。
7）、mkdir: 新建一个目录,就是新建一个文件夹。
8）、rm -r : 删除一个文件夹, rm -r src 删除src目录， 好像不能用通配符。
9）、mv 移动文件, mv index.html src index.html 是我们要移动的文件, src 是目标文件夹,当然, 这样写,必须保证文件和目标文件夹在同一目录下。
10）、reset 重新初始化终端/清屏。
11）、clear 清屏。
12）、history 查看命令历史。
13）、help 帮助。
14）、exit 退出。
15）、#表示注释git remote：查看远程库信息 
git remote -v：远程库详细信息
git branch -r ， git branch -a 查看远程分支
git push 将当前分支推送到远程对应的分支（若远程无对应分支，则推送无效） 
git push origin dev 将分支dev提交到远程origin/dev（远程没有则创建, 远程没有dev则创建） 
git branch –set-upstream branch-name origin/branch-name 建立本地分支和远程分支的关联
git checkout -b dev origin/dev 创建远程的origin/dev分支到本地
```
```
查看分支：git branch 
创建分支：git branch name 
切换分支：git checkout name 工作区文件内容会立即变化成对应分支的内容 
创建+切换分支：git checkout -b name 
合并某分支到当前分支：git merge name 
删除分支：git branch -d name
查看分支合并情况：git log –graph –pretty=oneline –abbrev-commit
合并分支（fast forward）：git merge name 
合并分支（禁用 Fast forward）：git merge –no-ff -m “描述” dev
```
```
1、创建标签git tag tagname 对当前版本建立标签 
  git tag tagname commit_id 对历史版本建立标签 
  git tag -a tagname -m “描述…” commit_id 添加说明 
  git tag 查看所有标签 
  git show tagname 查看某个标签具体信息
2、删除标签
  git tag -d tagname 删除本地标签
3、推送标签 
  git push origin tagname 推送本地的某个标签到远程 git push origin –tags 一次性推送所有分支
4、删除远程标签
  git tag -d tagname 先删除本地 git push origin :refs/tags/tagname 从远程删除
```
```
# 添加指定文件到暂存区
  git add [file1] [file2] ...
# 添加指定目录到暂存区，包括子目录
  git add [dir]
# 添加当前目录的所有文件到暂存区
  git add .
```