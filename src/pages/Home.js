import React from 'react'
import MainLayout from '../layouts/MainLayout'
import WelcomeSection from "../components/Home/WelcomeSection"
import MainSection from "../components/Home/MainSection"
import InfoSection from '../components/Home/InfoSection'

function Home() {
  return (
    <MainLayout>
        <WelcomeSection />
        <MainSection />
        <InfoSection />
    </MainLayout>
  )
}

export default Home