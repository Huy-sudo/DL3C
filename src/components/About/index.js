import React, { useState } from 'react'
import InfoBlock from "./InfoBlock"
import styles from "./index.module.css"

function AboutUs() {
    const [info, setInfo] = useState([
        {
            id: "1",
            element1: `<img src="https://cdnimg.vietnamplus.vn/uploaded/ifysv/2014_12_02/tp2.jpg" alt =""/>`,
            element2: "<p>Nhà hát nằm ở địa chỉ số 7 đường Công Trường Lam Sơn, phường Bến Nghé, quận 1, có kiến trúc đặc biệt, mang đậm phong cách Gothic thịnh hành ở Pháp cuối thế kỷ 19, vì thế nhà hát tại Sài Gòn có đôi nét kiến trúc giống với nhà hát Lớn tại Hà Nội.</p>"
        },
        {
            id: "2",
            element2: `<img src="https://cdn.justfly.vn/1920x1440/media/202109/27/1632735914-tham-quan-nha-hat-lon-sai-gon-17.jpg" alt =""/>`,
            element1: "<p>Nhà hát lớn thành phố Hồ Chí Minh được xem là một địa danh văn hoá lịch sử lâu đời. Nhà hát được khánh thành vào ngày 1 tháng 1 năm 1900 bởi chính quyền Pháp. Nơi đây được xây dựng với mục đích sẽ trở thành một trung tâm giải trí dành riêng cho những vị khách sang trọng.</p>"
        },
        {
            id: "3",
            element1: `<img src="https://cdn.justfly.vn/1920x1397/media/202109/27/1632735914-tham-quan-nha-hat-lon-sai-gon-16.jpg" alt =""/>`,
            element2: "<p>Nhà hát thành phố thuộc loại di tích kiến trúc nghệ thuật; Diện tích 2016m². Nhà hát lớn Sài Gòn là một đối trọng về mặt kiến trúc với Nhà hát lớn Hà Nội (cất năm 1911, kiến trúc theo mẫu Opéra Garnier tại Paris, 900 chỗ ngồi, kiến trúc sư Broger et Harloy). Nhà hát Sài Gòn giữ riêng nét đặc thù có một không hai. Tác giả của tòa kiến trúc này là các kiến trúc sư Félix Olivier, Ernest Guichard và Eugène Ferret xây dựng năm 1900 theo lối kiến trúc của thời Đệ tam cộng hòa Pháp.</p>"
        },
        {
            id: "4",
            element2: `<img src="https://cdn.justfly.vn/1920x2400/media/202109/27/1632735914-tham-quan-nha-hat-lon-sai-gon-1.jpg" alt =""/>`,
            element1: "<p>Cửa mặt tiền chịu ảnh hưởng nghệ thuật khá rõ nét của Petit Palais cất cùng năm tại Pháp. Thiết kế bên trong tân tiến với đầy đủ thiết bị cho âm thanh và ánh sáng. Ngoài tầng trệt còn 2 tầng lầu tổng cộng 1800 chỗ ngồi. Toàn bộ các mẫu trang trí, phù điêu mặt tiền và nội thất đều được một họa sĩ tên tuổi ở Pháp vẽ giống như mẫu của các nhà hát ở Pháp cuối thế kỷ 19 và gửi từ Pháp qua.</p>"
        },
        {
            id: "5",
            element1: `<img src="https://cdn.justfly.vn/1920x1920/media/202109/27/1632735914-tham-quan-nha-hat-lon-sai-gon-5.jpg" alt =""/>`,
            element2: "<p>Tuy vậy, về phần trang trí ở mặt tiền nhà hát cũng có nhiều lời chỉ trích. Theo phong cách Đế quốc (sau được trang trí thêm theo phong cách Beaux Arts, rồi giản tiện hóa kiểu Art Deco), mặt tiền nhà hát được trang trí nhiều phù điêu và tượng đắp nổi giống như tòa thị chính, nên bị chỉ trích là khá rườm rà và rối rắm. Vì vậy vào năm 1943, một số chi tiết trang trí này đã bị dỡ bỏ với mục đích trẻ trung hóa phong cách kiến trúc.</p>"
        },
        {
            id: "6",
            element2: `<img src="https://cdn.justfly.vn/1920x1922/media/202109/27/1632735914-tham-quan-nha-hat-lon-sai-gon-2.jpg" alt =""/>`,
            element1: "<p>Nhà hát thành phố có kiến trúc cổ kính, uy nghi với 1 tầng trệt, hai tầng lầu, 1800 ghế, không khí thoáng, hệ thống âm thanh ánh sáng hiện đại, là nơi tổ chức biểu diễn sân khấu chuyên nghiệp như: biểu diễn kịch nói, cải lương, ca nhạc, múa Balê, dân tộc, Opera cho tất cả các đoàn nghệ thuật trong và ngoài nước.</p>"
        }
    ]);

    return (
        <section>
            <section className={styles.container}>
                <h2 className={styles.header}>THAM QUAN NHÀ HÁT</h2>
                <p style={{fontSize: "22px", maxWidth: "60%"}}>Nhà hát lớn thành phố Hồ Chí Minh hay còn được gọi ngắn gọn là Nhà hát Thành phố hoặc Nhà hát Lớn. Là nơi chuyên tổ chức và biểu diễn các tiết mục nghệ thuật, đồng thời có thể sử dụng để tổ chức một số sự kiện lớn thu hút rất nhiều người tới thăm quan. Du khách đã có cơ hội ghé thăm nơi này chưa? Nếu câu trả lời là chưa thì hãy cùng tìm hiểu và khám phá kiến trúc độc đáo của Nhà hát Lớn này nhé!</p>
                {
                    info.map(item => {
                        return (
                            <InfoBlock key={item.id} element1={item.element1} element2={item.element2} />
                        )
                    })
                }
                <h2 className={styles.header}>MỘT SỐ HOẠT ĐỘNG</h2>
                <p style={{fontSize: "22px", maxWidth: "60%"}}>5 shows diễn nhất định phải xem khi đến Nhà hát Thành phố</p>
                <ul>
                    <li>À Ố Show</li>
                    <li>Opera Gala</li>
                    <li>The Mist</li>
                    <li>Nhạc kịch - Vũ kịch</li>
                    <li>Các chương trình âm nhạc Việt Nam</li>
                </ul>
            </section>
        </section>
    )
}

export default AboutUs

