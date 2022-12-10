import React, { useState } from 'react'
import InfoBlock from "./InfoBlock"
import styles from "./index.module.css"

function InfoSection() {
    const [info, setInfo] = useState([
        {
            id: "1",
            title: "<h4>Lối kiến trúc <i>flamboyant</i> của thời Đệ tam Cộng hòa Pháp</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh - với lịch sử phát triển hàng trăm năm - được xem như cái nôi \"nghệ thuật\" tại địa phương, nơi có các chương trình biểu diễn quy mô lớn"
        },
        {
            id: "2",
            title: "<h4>Lối kiến trúc <i>flamboyant</i> của thời Đệ tam Cộng hòa Pháp</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh - với lịch sử phát triển hàng trăm năm - được xem như cái nôi \"nghệ thuật\" tại địa phương, nơi có các chương trình biểu diễn quy mô lớn</p>"
        },
        {
            id: "3",
            title: "<h4>Lối kiến trúc <i>flamboyant</i> của thời Đệ tam Cộng hòa Pháp</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh - với lịch sử phát triển hàng trăm năm - được xem như cái nôi \"nghệ thuật\" tại địa phương, nơi có các chương trình biểu diễn quy mô lớn</p>"
        },
        {
            id: "4",
            title: "<h4>Lối kiến trúc <i>flamboyant</i> của thời Đệ tam Cộng hòa Pháp</h4>",
            description: "<p>Nhà hát Thành phố Hồ Chí Minh - với lịch sử phát triển hàng trăm năm - được xem như cái nôi \"nghệ thuật\" tại địa phương, nơi có các chương trình biểu diễn quy mô lớn</p>"
        }
    ]);

    return (
        <section className={styles.container}>
            <h2>Một số điểm nổi bật</h2>
            <div className={styles.item_box}>
                {info.map(item => {
                    return (
                        <InfoBlock key={item.id} title={item.title} description={item.description} id={item.id} />
                    )
                })}
            </div>
        </section>
    )
}

export default InfoSection

