import TopicElementInfo, { topicTypeMap } from "../../../../commonTypes/TopicElementInfo";

function TopicContentItem ({id, type, innerText}:TopicElementInfo) {

    const ContentType = topicTypeMap[type];
    return <ContentType key={id} innerText={innerText} />;
}

export default TopicContentItem;