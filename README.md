# 光束心境

响应式 HTML、CSS 和 JavaScript 粒子爱心。手机和电脑可用摄像头，也可通过触屏或鼠标操作。手部推理在浏览器内完成。

## 运行与部署

解压整个源码包。在该目录执行 python -m http.server 8000，然后在本机浏览器访问 http://localhost:8000 。手机远程访问时，将目录内容部署到提供 HTTPS 的静态网站服务。index.html 与 vision/ 应保持相同的相对位置。服务器应将 .mjs 作为 JavaScript、.wasm 作为 application/wasm 发送。无需构建、API 密钥或 ChatGPT 账号。

## 修改与再分发

index.html 包含完整页面、粒子动画、手势映射、摄像头生命周期以及触屏操作代码。vision/ 包含推理所需的运行时与模型。光束心境原创应用代码采用 Apache License 2.0，详见 LICENSE.txt。第三方组件及其来源见 THIRD-PARTY.txt。

页面的源码入口指向同目录的 source.zip。自行部署时可将下载的源码包一并上传为 source.zip；修改代码后，用更新后的 index.html、vision、说明和许可证重新制作该包。
