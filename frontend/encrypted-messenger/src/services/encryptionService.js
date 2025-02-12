import JSEncrypt from 'jsencrypt';

const generate = async () => {
  try {
    const encrypt = new JSEncrypt({ default_key_size: 512 }); 
    const publicKey = encrypt.getPublicKey(); 
    const privateKey = encrypt.getPrivateKey();

    console.log("Public Key:", publicKey);
    console.log("Private Key:", privateKey);

    return { publicKey, privateKey };
  } catch (error) {
    console.error("Error generating key:", error);
    throw error;
  }
};

const encrypt = (data, publicKey) => {
  const encrypt = new JSEncrypt();
  encrypt.setPublicKey(publicKey); 
  return encrypt.encrypt(data); 
};

const decrypt = (encryptedData, privateKey) => {
  const decrypt = new JSEncrypt();
  decrypt.setPrivateKey(privateKey); 
  return decrypt.decrypt(encryptedData);
};


export { generate, encrypt, decrypt };