const openIndexedDB = () => {
    return new Promise((resolve, reject) => {
      const request = indexedDB.open("UserKeysDB", 1);
    
      request.onupgradeneeded = (event) => {
        const db = event.target.result;
        if (!db.objectStoreNames.contains("keys")) {
          db.createObjectStore("keys", { keyPath: "username" }); 
        }
      };
  
      request.onsuccess = (event) => resolve(event.target.result);
      request.onerror = (event) => reject(event.target.error);
    });
  };


const savePrivateKeyToIndexedDB = async (username, privateKey) => {
    const db = await openIndexedDB();
    return new Promise((resolve, reject) => {
      const transaction = db.transaction(["keys"], "readwrite");
      const store = transaction.objectStore("keys");
  
      const request = store.put({ username, privateKey });
      request.onsuccess = () => resolve();
      request.onerror = (event) => reject(event.target.error);
    });
  };
  
  const getPrivateKeyFromIndexedDB = async (username) => {
    const db = await openIndexedDB();
    return new Promise((resolve, reject) => {
      const transaction = db.transaction(["keys"], "readonly");
      const store = transaction.objectStore("keys");
  
      const request = store.get(username); 
      request.onsuccess = (event) => resolve(event.target.result?.privateKey);
      request.onerror = (event) => reject(event.target.error);
    });
  };

  export {savePrivateKeyToIndexedDB};
  export {getPrivateKeyFromIndexedDB};