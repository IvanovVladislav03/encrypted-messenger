import forge from "node-forge"

const generate = async () => {
  try {
    const keypair = forge.pki.rsa.generateKeyPair({bits: 2048, e: 0x10001});
    const publicKeyPem = forge.pki.publicKeyToPem(keypair.publicKey);
    const privateKeyPem = forge.pki.privateKeyToPem(keypair.privateKey);
    return { publicKey: publicKeyPem, privateKey: privateKeyPem };
  } catch (error) {
    console.error("Error generating key:", error);
    throw error; 
  }
};

export { generate };
