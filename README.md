# 光束心境

手机与电脑通用的光束粒子爱心，采用 Apache-2.0 许可证。页面打开后会在本机初始化内置模型，摄像头需要用户点击授权。视频帧在浏览器中处理。

## 运行

将 index.html 上传到 HTTPS 静态网站即可。桌面端也可以把它保存后用浏览器直接打开。手部模型、JavaScript 运行时和 WebAssembly 已全部打包于 index.html 中。

## 修改与构建

修改 page.html 中的界面、动画或手势映射，然后在本目录运行 node build.cjs，生成 index.html。无需安装 npm 依赖。vision/ 包含可重现构建所需的 MediaPipe 文件，具体版本与来源见 THIRD-PARTY.txt。

## Windows 桌面版

双击光束心境.exe 运行。程序使用本机的 Microsoft Edge 或 Google Chrome 提供独立应用窗口，页面和模型已嵌入 EXE。使用摄像头时，请点击开启并授权。

在 Windows 安装 Node.js 后，修改 page.html，并在源码根目录执行 powershell -ExecutionPolicy Bypass -File desktop/build.ps1。脚本会生成 index.html 和 desktop/Heartbeam.exe。将 index.html 上传到静态网站即可更新网页版。桌面启动器源码位于 desktop/Program.cs。

## 安卓和 iPhone

通过 HTTPS 打开网页版，从浏览器菜单添加到主屏幕。manifest.webmanifest 定义应用入口，sw.js 保存完整版页面。首次联网打开并完成缓存后，可从主屏幕离线启动。摄像头使用浏览器或系统授权。
