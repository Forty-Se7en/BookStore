
import { Layout } from "antd";
import "./globals.css";
import Menu from "antd/es/menu/menu";
import { Content, Footer, Header } from "antd/es/layout/layout";
import Link from "next/link";

const items = [
  { key: "home", label: <Link href={"/"}>Дом</Link> },
  { key: "books", label: <Link href={"/books"}>Книги</Link> },
]

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body>
        <Layout style={{ minHeight: "100vh" }}>
          <Header>
            <Menu
              theme="dark"
              mode="horizontal"
              items={items}
              style={{ flex: 1, minWidth: 0 }}>
            </Menu>
          </Header>
          <Content style={{ padding: "0 48px" }}>
            {children}
          </Content>
          <Footer style={{ textAlign: "center" }}> Created by Evgeniy Enikeev </Footer>
        </Layout>
      </body>
    </html>
  );
}
