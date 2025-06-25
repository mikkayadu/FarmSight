import React, { useEffect, useState } from "react";
import "../styles/Anomaly.css";
import Footer from "../components/Footer.jsx";

const Anomaly = () => {
  const [alert, setAlert] = useState(null);

  useEffect(() => {
    // 👉 Later: replace with fetch(`/api/alerts`)
    setAlert({
      status: "Open",
      severity: "Unknown",
      priority: "Medium",
      created: "24 June 2025",
      caseName: "Drought Risk - Zone A",
      caseID: "DR-2406-ZA",
      history: [
        { date: "22 June", status: "Open" },
        { date: "20 June", status: "Resolved" },
        { date: "17 June", status: "Open" },
      ],
    });
  }, []);

  if (!alert) return <p className="anomaly-page">Loading alert...</p>;

  return (
    <>
    <div className="anomaly-page">
      <div className="anomaly-header">
        <h2>📢 Anomaly Alert</h2>
        <button className="alert-btn">Alert Options</button>
      </div>

      {/* STATUS SECTION */}
      <div className="anomaly-cards">
        <div className="anomaly-card">
          <h4>Status</h4>
          <p className="status open">🟠 {alert.status}</p>
          <p>Severity: {alert.severity}</p>
          <p>Priority: 🔴 {alert.priority}</p>
        </div>

        <div className="anomaly-card">
          <h4>Alert Details</h4>
          <p>Created: {alert.created}</p>
          <p>Case Name: {alert.caseName}</p>
          <p>Case ID: {alert.caseID}</p>
        </div>
      </div>

      {/* HISTORY SECTION */}
      <div className="alert-history">
        <h3>📅 History</h3>
        <ul>
          {alert.history.map((entry, idx) => (
            <li key={idx}>
              <strong>{entry.date}</strong> – <span className="badge">{entry.status}</span>
            </li>
          ))}
        </ul>
      </div>

      {/* DECOR */}
      <div className="anomaly-footer-img">
        <img src="/tractor-farmer.png" alt="Farmer Icon" />
      </div>
    </div>
    <Footer/>
    </>
  );
};

export default Anomaly;