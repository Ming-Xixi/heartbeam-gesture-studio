const cacheName='heartbeam-mobile-v1';
const home=new URL('./',self.location).href;
self.addEventListener('install',event=>{
  event.waitUntil(caches.open(cacheName).then(cache=>cache.add(home)));
});
self.addEventListener('activate',event=>{
  event.waitUntil(self.clients.claim());
});
self.addEventListener('fetch',event=>{
  const url=new URL(event.request.url);
  if(event.request.mode!=='navigate'||(url.pathname!==new URL(home).pathname&&url.pathname!==new URL('index.html',home).pathname))return;
  event.respondWith(fetch(event.request).then(async response=>{
    if(response.ok){const cache=await caches.open(cacheName);await cache.put(home,response.clone())}
    return response
  }).catch(()=>caches.match(home,{cacheName})));
});
