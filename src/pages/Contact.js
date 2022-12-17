import React from 'react'
import ContactForm from '../components/Contact/ContactForm'
import MainLayout from '../layouts/MainLayout'
import ImageBlock from '../components/Contact/ImageBlock'
import styles from "./Contact.module.css";

function Contact() {
  const imageList = [{
    id: 1,
    url: "https://dulich3mien.vn/wp-content/uploads/2021/12/hinh-anh-nha-hat-thanh-pho-1-1.jpg",
    title: "NHÀ HÁT VỀ ĐÊM"
  },
  {
    id: 2,
    url: "https://www.luneproduction.com/content/images/thumbs/0002384_0_image.jpeg",
    title: "QUY MÔ NHÀ HÁT"
  },
  {
    id: 3,
    url: "https://res.klook.com/images/fl_lossy.progressive,q_65/c_fill,w_1500,h_1001,f_auto/w_80,x_15,y_15,g_south_west,l_Klook_water_br_trans_yhcmh3/activities/u6bkg0ud8zbbtcqztp66/V%C3%A9%C3%80%E1%BB%90Showt%E1%BA%A1iNh%C3%A0H%C3%A1tTh%C3%A0nhPh%E1%BB%91H%E1%BB%93Ch%C3%ADMinh-KlookVi%E1%BB%87tNam.jpg",
    title: "SHOW DIỄN ĐẶC SẮC"
  }
]
  return (
    <MainLayout>
        <ContactForm></ContactForm>
        <div className={styles.image_list}>
        {imageList.map(item => {
          return (
            <ImageBlock key={item.id} url={item.url} title={item.title}/>
          )
        })}
        </div>
    </MainLayout>
  )
}

export default Contact