# 光束心境

手机与电脑通用的光束粒子爱心，采用 Apache-2.0 许可证。页面打开后会在本机初始化内置模型，摄像头需要用户点击授权。视频帧在浏览器中处理。

## 运行

将 index.html 上传到 HTTPS 静态网站即可。桌面端也可以把它保存后用浏览器直接打开。手部模型、JavaScript 运行时和 WebAssembly 已全部打包于 index.html 中。

## 修改与构建

修改 page.html 中的界面、动画或手势映射，然后在本目录运行 node build.cjs，生成 index.html。无需安装 npm 依赖。vision/ 包含可重现构建所需的 MediaPipe 文件，具体版本与来源见 THIRD-PARTY.txt。
