'use client'
import { useState } from 'react';
import { useRouter } from 'next/navigation';
import Cookie from 'js-cookie';
import SendImageApi from '../../api/MyProfileUpload'
import GiveImageApi from '../../api/MyProfileGiveImage.js'
import ReceiptDisplay from '../../components/DisplayReceipt';

export default function MyProfile() {
  const router = useRouter();

  const Logout = () => {
    Cookie.remove('authToken');
    router.push('/');
  };

  const [imageUpload, setImageUpload] = useState(null);
  const [sendImageInfo, setSendImageInfo] = useState('');
  const [giveImageOffset, setGiveImageOffset] = useState(0);

  const [imageDownload, setImageDownload] = useState(null);

  const changeImage = (e) => {
    const file = e.target.files?.[0];  // Use optional chaining to prevent errors if files is undefined
    setImageUpload(file);
  };

  const handleImageUpload = (e) => {
    if (imageUpload) {
      SendImageApi(imageUpload) // Send the file to the API
        .then((status) => {
          setSendImageInfo(`Image uploaded successfully with status: ${status}`);
        })
        .catch((error) => {
          setSendImageInfo(`Error uploading image: ${error}`);
        });
    } else {
      setSendImageInfo(`No file selected or invalid file input.`);
    }
  };

  const handleGiveImage = async (e) => {
    try {
      const response = await GiveImageApi(giveImageOffset);
      if (response.status != 200) {
        setImageDownload(null);
      }
      else {
        setImageDownload(response.data);
      }
    }
    catch
    {
      setImageDownload(null);
    }
  };

  return (
    <div className='text-center'>
      <button className='pt-10' onClick={Logout}>Logout</button>
       <div className='pt-10'>
        <h1 className='pt-10'>Upload image</h1>
        <input type="file" accept="image/*" onChange={changeImage}/>
        <button onClick={handleImageUpload}>Upload image</button>
        <p>{sendImageInfo}</p>
      </div>
      <div>
        <h1 className='pt-10'>give me image</h1>
        <input type="text" value={giveImageOffset} onChange={(e) => setGiveImageOffset(e.target.value)} className='text-black'/>
        <button onClick={handleGiveImage}>give image</button>
      </div>
      <div>
        {imageDownload ? (
          <ReceiptDisplay data={imageDownload}></ReceiptDisplay>
        ) : (
          <p>No data</p>
        )}
      </div>
    </div>
  );
}
