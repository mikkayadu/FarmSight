import React, { useEffect, useState } from "react";
import "../styles/Settings.css";

const BASE     = import.meta.env.VITE_API_BASE || "http://localhost:7005";
const token    = localStorage.getItem("token")    || ""; // TODO real JWT
const farmerId = localStorage.getItem("farmerId") || ""; // TODO real ID

const Settings = () => {
  /*────────── state ──────────*/
  const [preview, setPreview] = useState(null);
  const [loading, setLoading] = useState(true);
  const [form, setForm] = useState({
    firstName: "",
    surname: "",
    phone: "",
    email: "",
    company: "",
    cropType: "maize",
    coords: "",
  });
  const [message, setMessage] = useState("");

  /*──────── fetch farmer profile ────────*/
  useEffect(() => {
    const fetchProfile = async () => {
      if (!farmerId || !token) {
        // fallback demo values
        setForm({
          firstName: "Nana",
          surname: "Yaa",
          phone: "+233...",
          email: "nana@example.com",
          company: "",
          cropType: "maize",
          coords: "",
        });
        setLoading(false);
        return;
      }

      try {
        const res = await fetch(`${BASE}/api/Farmer/${farmerId}`, {
          headers: { Authorization: `Bearer ${token}` },
        });
        const data = await res.json();
        setForm({
          firstName: data.firstName,
          surname: data.surname,
          phone: data.phone,
          email: data.email,
          company: data.company,
          cropType: data.cropType,
          coords: data.coords,
        });
      } catch (err) {
        console.error("Profile fetch failed:", err);
      } finally {
        setLoading(false);
      }
    };
    fetchProfile();
  }, []);

  /*───────── handlers ─────────*/
  const handleImageChange = (e) => {
    const file = e.target.files[0];
    if (file) setPreview(URL.createObjectURL(file));
  };

  const handleChange = (e) =>
    setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!farmerId || !token) return;

    try {
      const res = await fetch(`${BASE}/api/Farmer/${farmerId}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(form),
      });
      if (res.ok) setMessage("Saved ✓");
      else        setMessage("Save failed");
      setTimeout(() => setMessage(""), 3000);
    } catch (err) {
      console.error("Update failed:", err);
      setMessage("Save failed");
    }
  };

  if (loading) return <p style={{ padding: "2rem" }}>Loading settings…</p>;

  /*────────── UI ──────────*/
  return (
    <div className="settings-container">
      <div className="settings-card">
        <h2>Your Profile Settings</h2>

        <div className="profile-pic-update">
          <label htmlFor="profilePic">
            {preview ? (
              <img src={preview} alt="Profile" />
            ) : (
              <div className="upload-placeholder">Upload Photo</div>
            )}
          </label>
          <input
            type="file"
            id="profilePic"
            accept="image/*"
            onChange={handleImageChange}
            hidden
          />
        </div>

        <form onSubmit={handleSubmit}>
          <input
            name="firstName"
            value={form.firstName}
            onChange={handleChange}
            placeholder="First Name"
            required
          />
          <input
            name="surname"
            value={form.surname}
            onChange={handleChange}
            placeholder="Surname"
            required
          />
          <input
            name="phone"
            value={form.phone}
            onChange={handleChange}
            placeholder="Phone Number"
            required
          />
          <input
            type="email"
            name="email"
            value={form.email}
            onChange={handleChange}
            placeholder="Email Address"
            required
          />
          <input
            name="company"
            value={form.company}
            onChange={handleChange}
            placeholder="Company Name"
          />

          <label htmlFor="crop">Crop Type</label>
          <select
            id="crop"
            name="cropType"
            value={form.cropType}
            onChange={handleChange}
          >
            <option value="maize">Maize</option>
            <option value="cassava">Cassava</option>
            <option value="yam">Yam</option>
            <option value="tomato">Tomato</option>
            <option value="other">Other</option>
          </select>

          <label>Farm Coordinates (optional)</label>
          <input
            name="coords"
            value={form.coords}
            onChange={handleChange}
            placeholder="Latitude, Longitude"
          />

          <button type="submit">Save Changes</button>
          {!!message && <p style={{ marginTop: "0.5rem" }}>{message}</p>}
        </form>
      </div>
    </div>
  );
};

export default Settings;
