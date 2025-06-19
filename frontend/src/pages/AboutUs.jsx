import React from "react";
import "../styles/AboutUs.css";
import Farouk from "../assets/profile.jpg";
import Me from "../assets/me.jpg";
import Micheal from "../assets/profile.jpg";
import Godwin from "../assets/profile.jpg";
import Footer from "../components/Footer.jsx";
import Navbar from "../components/Navbar.jsx";

const teamMembers = [
  {
    name: "Nana Yaa", // you 😎
    role: "Frontend Developer",
    image: Me,
    institution: 'University of Ghana',
    phone: '0570046841',
  },
  {
    name: "Farouk",
    role: "Backend Developer",
    image: Farouk,
    institution: 'University of Ghana',
    phone: '0205164254',
  },
  {
    name: "Godwin",
    role: "UI/UX Designer",
    image: Godwin,
    institution: 'University of Ghana',
    phone: '0505152231',
  },
  {
    name: "Michael",
    role: "AI/ML Developer",
    image: Micheal,
    institution: 'University of Ghana',
    phone: '0502317890'
  },
];

const AboutUs = () => {
  return (
   <>
    <Navbar />
    <div className="about-container">
      {/* Centered About Text Card */}
      <div className="about-card">
        <h1>About FarmSight</h1>
        <p>
          FarmSight is an intelligent platform designed to empower smallholder farmers across Sub-Saharan Africa with real-time insights from space.
          Using satellite Earth Observation data, AI, and predictive analytics, we help farmers track crop health, detect climate risks, and improve decisions.
        </p>
        <p>
          Whether you're planting maize in Tamale or managing cocoa fields in Kumasi, FarmSight gives you actionable insights — all in one smart dashboard.
        </p>
        <p>
          This platform was built as part of GAIAthon 2025, by a team of passionate innovators from the University of Ghana.
        </p>
      </div>

      {/* New Team Section BELOW main card */}
      <div className="team-section">
        <h2 className="team-heading">Meet the Team</h2>
        <div className="team-grid">
          {teamMembers.map((member, index) => (
            <div key={index} className="team-card">
              <img src={member.image} alt={member.name} className="team-photo" />
              <h3>{member.name}</h3>
              <p>{member.role}</p>
              <p>{member.institution}</p>
              <p>{member.phone}</p>
            </div>
          ))}
        </div>
      </div>
    </div>
    <Footer/>
   </>
  );
};

export default AboutUs;
