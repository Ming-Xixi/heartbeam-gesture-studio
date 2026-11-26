const fs=require('node:fs'),path=require('node:path');
const root=__dirname;
const {gzipSync}=require('node:zlib');
const files=['vision.mjs','hand.task','vision_wasm_internal.js','vision_wasm_internal.wasm','vision_wasm_nosimd_internal.js','vision_wasm_nosimd_internal.wasm'];
const assets=Object.fromEntries(files.map(file=>[file,gzipSync(fs.readFileSync(path.join(root,'vision',file)),{level:9}).toString('base64')]));
const template=fs.readFileSync(path.join(root,'page.html'),'utf8');
fs.writeFileSync(path.join(root,'index.html'),template.replace('/* INLINE_GZIP_DECODER */',()=>fs.readFileSync(path.join(root,'vision','fflate.js'),'utf8')).replace('/* EMBEDDED_VISION_FILES */ {}',()=>JSON.stringify(assets)));
