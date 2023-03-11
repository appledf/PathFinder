# WRobot PathEditor v2.1 插件 使用wow 60版

此插件基于https://github.com/srazdokunebil/PathEditor 基础二次开发。尤其很多功能有别人基础，故另立项目。

## Dependencies

- WRobot (https://wrobot.eu/files/file/2-wrobot-official/)
- World of Warcraft 1.12.1 (5875)

## 安装

- 复制 PathEditor.dll in **[wrobot root]\Plugins**
- 复制 PathFinder 到 **[wow]\Interface\AddOns**
- 创建 **[wrobot root]\PathFinder_Path** 路径

## 配置



 **序** | **宏** | **功能** 
---|---|---
 1 | `/pe add` | 路径最尾部增加点信息。
 2 | `/pe del` | 删除最近点信息
 3 | `/pe new` | 创建新的路径。并删除原有路径信息。
 4 | `/pe reposition` | 移动到最近的点位置。
 5 | `/pe showindex` | 显示最近点信息。包括：序号，坐标位置。
 6 | `/pe save` | 保存路径信息到xml文件。
 7 | `/pe insert` | 插入最近点位置。（显示蓝色）
 8 | `/pe secondary` | 插入副节点。（显示黄色）
 9 | `/pe minimap` | 刷新小地图
 10| `/pe mark` | 标记最近点为目标点。（显示红色）
 11| `/pe reload` | 重载xml文件。
 
## 使用说明

wow插件选中PathFinder加载后，运行wow会自动显示插件界面。
